using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using System.Text.Json;
using WebSocketSharp;
using System.Collections.Generic;
using Nasfaq.JSON;
using YeastLib;

namespace Nasfaq.API
{
    /*
    socket.io ws urls:
    EIO: the version of the protocol (currently, “4”)
    transport: the transport name (“polling” or “websocket”)
    sid: the session ID
    j: if the transport is polling but a JSONP response is required
    t: a hashed-timestamp used for cache-busting

    send 2probe = i wanna get socket bro
    receive 3probe = yeah bro lets socket bro
    receive 2 = u alive bro?
    send 3 = yea im alive bro we cool
    receive 42 = heres the data bro
    send 43 = im stuffed i dont want more data bro

    */
    public class SocketIO : IDisposable
    {
        string restUrl;
        string wsUrl;
        WebSocket ws;

        public event Action OnOpen;
        public event Action<byte[]> OnMessage;
        public event Action<IWebsocketData> OnWebsocketData;
        public event Action<string> OnError;

        static readonly List<(string, string)> headers = new List<(string, string)>
        {
            ("Accept", "*/*"),
            ("Accept-Language", "en-US,en;q=0.5"),
            ("Accept-Encoding", "gzip, deflate, br"),
            ("Connection", "keep-alive"),
            ("Sec-Fetch-Dest", "empty"),
            ("Sec-Fetch-Mode", "cors"),
            ("Sec-Fetch-Site", "same-origin"),
            ("User-Agent", "Mozilla/5.0"),
        };

        public static IWebsocketData BytesToSocketData(byte[] data)
        {
            return BytesToSocketData(data, out _, out _);
        }

        public static IWebsocketData BytesToSocketData(byte[] data, out string eventName, out WebsocketEventType eventType)
        {
            string message = SocketIO.BytesToString(data);
            IWebsocketData websocketData = default;
            try
            {
                websocketData = WebsocketReader.Read(message, out eventName, out eventType);
            }
            catch (Exception e)
            {
                eventName = null;
                eventType = WebsocketEventType.Public;
                Console.WriteLine($"Exception when trying to parse Websocket: {e.Message}\nOriginal message:\n{message}");
            }
            return websocketData;
        }

        public static string BytesToString(byte[] bytes)
        {
            return Encoding.UTF8.GetString(bytes);
        }

        public SocketIO(string rest, string ws)
        {
            this.restUrl = rest;
            this.wsUrl = ws;
        }

        public void Dispose()
        {
            if(ws != null)
            {
                ws.Send("43"); //stop
                ws.Close();
                ws = null;
            }
        }

        public bool IsOpen()
        {
            if(ws == null) return false;
            return ws.IsAlive;
        }

        public async Task ConnectAsync(HttpClient client, string userId, string socketId, Dictionary<string, string> fundIds = null, string cookies = null)
        {
            string eio = "EIO=4&";
            string tPolling = "transport=polling&";
            string tWebsocket = "transport=websocket&";
            string user = (userId != null) ? $"user={userId}&" : "";
            string socketid = (socketId != null) ? $"socketid={socketId}&" : "";
            string fundids = @"fundids=%7B";
            if(fundIds != null)
            {
                int i = 0;
                foreach(KeyValuePair<string, string> kvp in fundIds)
                {
                    fundids += $"%22{kvp.Key}%22%3A%22{kvp.Value}%22";
                    if(i != fundIds.Count - 1)
                    {
                        fundids +="%2C";
                    }
                    i++;
                }
            }
            fundids += "%7D&";

            //open packet
            string socketSIDjson = await HttpHelper.GET(
                client,
                $"{restUrl}?{user}{socketid}{fundids}{eio}{tPolling}t={Yeast.GetTimestamp()}", 
                headers,
                cookies);
            GetSocketIOSID socketSID = JsonSerializer.Deserialize<GetSocketIOSID>(socketSIDjson.Substring(1));
            string sid = $"sid={socketSID.sid}";
            
            //namespace connection request
            string response2 = await HttpHelper.POST(
                client,
                $"{restUrl}?{user}{socketid}{fundids}{eio}{tPolling}t={Yeast.GetTimestamp()}&{sid}", 
                headers, 
                "40",
                cookies);

            //namespace connection approval
            string response3 = await HttpHelper.GET(
                client,
                $"{restUrl}?{user}{socketid}{fundids}{eio}{tPolling}t={Yeast.GetTimestamp()}&{sid}", 
                headers,
                cookies);

            ws = new WebSocket($"{wsUrl}?{user}{socketid}{fundids}{eio}{tWebsocket}{sid}");
            
            ws.OnOpen += (sender, e) => { OnOpen?.Invoke(); };
            ws.OnMessage += (sender, e) => { OnMessageWrap(e, ws, OnMessage, OnWebsocketData); };
            ws.OnError += (StringReader, e) => { OnError?.Invoke(e.Message); };
            ws.Connect();
            ws.Send("2probe"); //send probe
        }

        public void DisconnectAsync()
        {
            if(ws != null)
            {
                ws.Send("43"); //stop
                ws.CloseAsync();
            }
        }

        private static void OnMessageWrap(MessageEventArgs e, WebSocket ws, Action<byte[]> OnMessage, Action<IWebsocketData> OnWebsocketData)
        {
            try
            {
                switch(e.Data[0])
                {
                    case '1': //close
                        ws.Close();
                        break;
                    case '2': //ping
                        ws.Send("3"); //pong
                        break;
                    case '3': //3probe
                        ws.Send("5");
                        break;
                    case '4': //message
                        switch(e.Data[1])
                        {
                            case '2': //event
                                byte[] bytes = e.RawData.SubArray(2, e.RawData.Length - 2);
                                OnMessage?.Invoke(bytes);
                                OnWebsocketData?.Invoke(BytesToSocketData(bytes));
                                break;
                            default:
                                throw new InvalidDataException("SocketIO: Unhandled Message: " + e.Data);
                        }
                        break;
                    default:
                        throw new InvalidDataException("SocketIO: Unhandled Message: " + e.Data);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


    }
}