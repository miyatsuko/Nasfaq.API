using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;

using Nasfaq.JSON;

namespace Nasfaq.API
{
    public class NasfaqAPI : IDisposable
    {
        HttpClient httpClient;
        SocketIO mainSocket;
        string holosesh;

        readonly List<(string, string)> headers;
        
        public NasfaqAPI(string holosesh)
        {
            this.holosesh = holosesh;

            Uri baseAddress = new Uri("https://nasfaq.biz/");
            CookieContainer cookieContainer = new CookieContainer();
            cookieContainer.Add(baseAddress, new Cookie("holosesh", holosesh));
            HttpClientHandler handler = new HttpClientHandler() { CookieContainer = cookieContainer};
            httpClient = new HttpClient(handler);

            mainSocket = new SocketIO("https://nasfaq.biz/socket/", "wss://nasfaq.biz/socket/");

            headers = new List<(string, string)>
            {
                ("Accept", "*/*"),
                ("Accept-Language", "en-US,en;q=0.5"),
                ("Accept-Encoding", "gzip, deflate, br"),
                ("Connection", "keep-alive"),
                ("Cookie", $"holosesh={holosesh}"),
                ("Host", "nasfaq.biz"),
                ("Origin", "https://nasfaq.biz"),
                ("Referer", "https://nasfaq.biz/market"),
                ("Sec-Fetch-Dest", "empty"),
                ("Sec-Fetch-Mode", "cors"),
                ("Sec-Fetch-Site", "same-origin"),
                ("User-Agent", "Mozilla/5.0"),
            };
        }

        ~NasfaqAPI()
        {
            Dispose();
        }

        public void Dispose()
        {
            mainSocket?.Dispose();
            httpClient?.Dispose();
        }

        public static long GetTimestamp(int year, int month, int day, int minutes = 0, int seconds = 0, int milliseconds = 0)
        {
            return new DateTimeOffset(new DateTime(year, month, day, minutes, seconds, milliseconds)).ToUnixTimeMilliseconds();
        }
        
        public async Task OpenSocketAsync()
        {
            await mainSocket.ConnectAsync(httpClient, $"holosesh={holosesh}");
            ////////////////////////////////AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
            mainSocket.OnOpen += () => {Console.WriteLine("open");};
            mainSocket.OnError += (s) => {Console.WriteLine(s);};
            mainSocket.OnMessage += (s) => {
                
                string message = null;
                unsafe
                {
                    fixed(byte* msgBytesPtr = s)
                    {
                        message = new string((sbyte*)msgBytesPtr, 0, s.Length);
                    }
                }
                Console.WriteLine(message);
                IWebsocketData iws = WebsocketReader.Read(message);
            };
        }

        public void CloseSocketAsync()
        {
            mainSocket.DisconnectAsync();
        }

        public async Task<string> AddMessage(AddMessage data)
        {
            return await HttpHelper.POST(
                httpClient,
                "https://nasfaq.biz/api/addMessage",
                headers,
                JsonSerializer.Serialize<AddMessage>(data)
            );
        }

        public async Task<string> AddReport(AddReport data)
        {
            return await HttpHelper.POST(
                httpClient,
                "https://nasfaq.biz/api/addReport",
                headers,
                JsonSerializer.Serialize<AddReport>(data)
            );
        }

        public async Task<string> AddRoom(AddRoom data)
        {
            return await HttpHelper.POST(
                httpClient,
                "https://nasfaq.biz/api/addRoom",
                headers,
                JsonSerializer.Serialize<AddRoom>(data)
            );
        }

        public async Task<string> BuySuperchat(BuySuperchat data)
        {
            return await HttpHelper.POST(
                httpClient,
                "https://nasfaq.biz/api/buySuperchat",
                headers,
                JsonSerializer.Serialize<BuySuperchat>(data)
            );
        }

        public async Task<string> ChangeEmail(ChangeEmail data)
        {
            return await HttpHelper.POST(
                httpClient,
                "https://nasfaq.biz/api/changeEmail",
                headers,
                JsonSerializer.Serialize<ChangeEmail>(data)
            );
        }

        public async Task<string> ChangeUsername(ChangeUsername data)
        {
            return await HttpHelper.POST(
                httpClient,
                "https://nasfaq.biz/api/changeUsername",
                headers,
                JsonSerializer.Serialize<ChangeUsername>(data)
            );
        }

        public async Task<string> RollGacha(RollGacha data)
        {
            return await HttpHelper.POST(
                httpClient,
                "https://nasfaq.biz/api/rollGacha",
                headers,
                JsonSerializer.Serialize<RollGacha>(data)
            );
        }

        public async Task<string> SetIcon(SetIcon data)
        {
            return await HttpHelper.POST(
                httpClient,
                "https://nasfaq.biz/api/setIcon",
                headers,
                JsonSerializer.Serialize<SetIcon>(data)
            );
        }

        public async Task<string> SetUserLeaderboardColor(SetUserLeaderboardColor data)
        {
            return await HttpHelper.POST(
                httpClient,
                "https://nasfaq.biz/api/setUserLeaderboardColor",
                headers,
                JsonSerializer.Serialize<SetUserLeaderboardColor>(data)
            );
        }

        public async Task<string> Trade(Trade data)
        {
            return await HttpHelper.POST(
                httpClient,
                "https://nasfaq.biz/api/trade",
                headers,
                JsonSerializer.Serialize<Trade>(data)
            );
        }

        public async Task<DestroySession> DestroySession()
        {
            return await HttpHelper.GET<DestroySession>(
                httpClient,
                "https://nasfaq.biz/api/destroySession",
                headers
            );
        }

        public async Task<GetAnnouncement> GetAnnouncement()
        {
            return await HttpHelper.GET<GetAnnouncement>(
                httpClient,
                "https://nasfaq.biz/api/getAnnouncement",
                headers
            );
        }

        public async Task<GetChatLog> GetChatLog(string roomid)
        {
            return await HttpHelper.GET<GetChatLog>(
                httpClient,
                $"https://nasfaq.biz/api/getChatLog?room={roomid}",
                headers
            );
        }

        public async Task<GetCooldown> GetCooldown()
        {
            return await HttpHelper.GET<GetCooldown>(
                httpClient,
                "https://nasfaq.biz/api/getCooldown",
                headers
            );
        }

        public async Task<GetDividends> GetDividends()
        {
            return await HttpHelper.GET<GetDividends>(
                httpClient,
                "https://nasfaq.biz/api/getDividends",
                headers
            );
        }

        public async Task<GetFloor> GetFloor()
        {
            return await HttpHelper.GET<GetFloor>(
                httpClient,
                "https://nasfaq.biz/api/getFloor",
                headers
            );
        }

        public async Task<GetGachaboard> GetGachaboard()
        {
            return await HttpHelper.GET<GetGachaboard>(
                httpClient,
                "https://nasfaq.biz/api/getGachaboard",
                headers
            );
        }

        public async Task<GetHistory> GetHistory(bool fullHistory, long timestamp = default)
        {
            string param = "";
            if(fullHistory) param = "?full";
            if(timestamp != default)
            {
                if(fullHistory) param += $"&timestamp={timestamp}";
                else param = $"?timestamp={timestamp}";
            }
            return await HttpHelper.GET<GetHistory>(
                httpClient,
                $"https://nasfaq.biz/api/getHistory{param}",
                headers
            );
        }

        public async Task<GetItemCatalogue> GetItemCatalogue()
        {
            return await HttpHelper.GET<GetItemCatalogue>(
                httpClient,
                "https://nasfaq.biz/api/getCatalogue",
                headers
            );
        }

        public async Task<GetLeaderboard> GetLeaderboard(bool leaderboard, bool oshiboard)
        {
            string param = "";
            if(leaderboard) param = "?leaderboard";
            if(oshiboard)
            {
                if(leaderboard) param += "&oshiboard";
                else param = "?oshiboard";
            }
            return await HttpHelper.GET<GetLeaderboard>(
                httpClient,
                $"https://nasfaq.biz/api/getLeaderboard{param}",
                headers
            );
        }

        public async Task<GetMarketInfo> GetMarketInfo(bool showPrice, bool showSaleValue, bool showInCirculation, bool showHistory)
        {
            return await GetMarketInfo("?all", showPrice, showSaleValue, showInCirculation, showHistory);
        }

        public async Task<GetMarketInfo> GetMarketInfo(IList<string> coins, bool showPrice, bool showSaleValue, bool showInCirculation, bool showHistory)
        {
            string coinsstr = "?coins=";
            for(int i = 0; i < coins.Count; i++)
            {
                coinsstr += coins[i];
                if(i + 1 < coins.Count - 1)
                {
                    coinsstr += ",";
                }
            }
            return await GetMarketInfo(coinsstr, showPrice, showSaleValue, showInCirculation, showHistory);
        }

        private async Task<GetMarketInfo> GetMarketInfo(string coins, bool showPrice, bool showSaleValue, bool showInCirculation, bool showHistory)
        {
            return await HttpHelper.GET<GetMarketInfo>(
                httpClient,
                $"https://nasfaq.biz/api/getMarketInfo{coins}&price={showPrice.ToString().ToLower()}&saleValue={showSaleValue.ToString().ToLower()}&inCirculation={showInCirculation.ToString().ToLower()}{(showHistory ? "&history" : "")}",
                headers
            );
        }

        public async Task<GetNews> GetNews()
        {
            return await HttpHelper.GET<GetNews>(
                httpClient,
                "https://nasfaq.biz/api/getNews",
                headers
            );
        }

        public async Task<GetSession> GetSession()
        {
            return await HttpHelper.GET<GetSession>(
                httpClient,
                "https://nasfaq.biz/api/getSession",
                headers
            );
        }

        public async Task<GetStats> GetStats()
        {
            return await HttpHelper.GET<GetStats>(
                httpClient,
                "https://nasfaq.biz/api/getStats",
                headers
            );
        }

        public async Task<GetSuperchats> GetSuperchats()
        {
            return await HttpHelper.GET<GetSuperchats>(
                httpClient,
                "https://nasfaq.biz/api/getSuperchats",
                headers
            );
        }

        public async Task<GetUserInfo> GetUserInfo()
        {
            return await HttpHelper.GET<GetUserInfo>(
                httpClient,
                "https://nasfaq.biz/api/getUserInfo",
                headers
            );
        }

        public async Task<GetUserItems> GetUserItems(string userid)
        {
            return await HttpHelper.GET<GetUserItems>(
                httpClient,
                $"https://nasfaq.biz/api/getUserItems?userid={userid}",
                headers
            );
        }

        public async Task<GetUserWallet> GetUserWallet(string userid)
        {
            return await HttpHelper.GET<GetUserWallet>(
                httpClient,
                $"https://nasfaq.biz/api/getUserWallet?userid={userid}",
                headers
            );
        }
    }
}
