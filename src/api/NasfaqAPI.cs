using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;

using Nasfaq.JSON;

namespace Nasfaq.API
{
    public partial class NasfaqAPI : IDisposable
    {
        public const int MAX_MULTICOIN = 10;
        public const int CYLCES_BETWEEN_ADJUSTMENTS = 24 * 6;
        public const int CYCLE_LENGTH_IN_SECONDS = 600;
        public static readonly string SERVER_TIMEZONE = "America/New_York";

        static NasfaqAPI()
        {
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                SERVER_TIMEZONE = "Eastern Standard Time";
        }

        HttpClient httpClient;
        SocketIO mainSocket;
        string holosesh;
        readonly List<(string, string)> headers;

        public event Action SocketOnOpen
        {
            add => mainSocket.OnOpen += value;
            remove => mainSocket.OnOpen -= value;
        }

        public event Action<byte[]> SocketOnMessage
        {
            add => mainSocket.OnMessage += value;
            remove => mainSocket.OnMessage -= value;
        }

        public event Action<IWebsocketData> SocketOnWebsocketData
        {
            add => mainSocket.OnWebsocketData += value;
            remove => mainSocket.OnWebsocketData -= value;
        }

        public event Action<string> SocketOnError
        {
            add => mainSocket.OnError += value;
            remove => mainSocket.OnError -= value;
        }
        
        public NasfaqAPI(string holosesh = null)
        {
            this.holosesh = holosesh;

            Uri baseAddress = new Uri("https://nasfaq.biz/");
            CookieContainer cookieContainer = new CookieContainer();
            if(holosesh != null)
            {
                cookieContainer.Add(baseAddress, new Cookie("holosesh", holosesh));
            }
            HttpClientHandler handler = new HttpClientHandler() { CookieContainer = cookieContainer};
            handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            httpClient = new HttpClient(handler);

            mainSocket = new SocketIO("https://nasfaq.biz/socket/", "wss://nasfaq.biz/socket/");

            headers = new List<(string, string)>
            {
                ("Accept", "*/*"),
                ("Accept-Language", "en-US,en;q=0.5"),
                ("Accept-Encoding", "gzip, deflate, br"),
                ("Connection", "keep-alive"),
                ("Host", "nasfaq.biz"),
                ("Origin", "https://nasfaq.biz"),
                ("Referer", "https://nasfaq.biz/market"),
                ("Sec-Fetch-Dest", "empty"),
                ("Sec-Fetch-Mode", "cors"),
                ("Sec-Fetch-Site", "same-origin"),
                ("User-Agent", "Mozilla/5.0"),
            };
            if(holosesh != null)
            {
                headers.Add(("Cookie", $"holosesh={holosesh}"));
            }
        }

        ~NasfaqAPI()
        {
            Dispose();
        }

        public void Dispose()
        {
            mainSocket?.DisconnectAsync();
            mainSocket?.Dispose();
            httpClient?.Dispose();
        }
        
        public async Task OpenSocketAsync(string userId = null, string socketId = null, Dictionary<string, string> fundIds = null)
        {
            await mainSocket.ConnectAsync(httpClient, userId, socketId, fundIds);
        }

        public void CloseSocketAsync()
        {
            mainSocket.DisconnectAsync();
        }

        public bool IsSocketOpen()
        {
            if(mainSocket == null) return false;
            return mainSocket.IsOpen();
        }
    }
}
