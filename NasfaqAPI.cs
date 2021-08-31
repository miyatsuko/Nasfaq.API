﻿using System;
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
        
        public async Task OpenSocketAsync()
        {
            await mainSocket.ConnectAsync(httpClient, $"holosesh={holosesh}");
            mainSocket.OnOpen = () => {Console.WriteLine("open");};
            mainSocket.OnError = (s) => {Console.WriteLine(s);};
            mainSocket.OnMessage = (s) => {

                Console.WriteLine(s);
                IWebsocketData iws = WebsocketReader.Read(s);
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

        public async Task<string> BuyCoin(BuyCoin data)
        {
            return await HttpHelper.POST(
                httpClient,
                "https://nasfaq.biz/api/buyCoin",
                headers,
                JsonSerializer.Serialize<BuyCoin>(data)
            );
        }

        public async Task<string> SellCoin(SellCoin data)
        {
            return await HttpHelper.POST(
                httpClient,
                "https://nasfaq.biz/api/sellCoin",
                headers,
                JsonSerializer.Serialize<SellCoin>(data)
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

        public async Task<GetChatLog> GetChatLog(string roomid = null)
        {
            return await HttpHelper.GET<GetChatLog>(
                httpClient,
                "https://nasfaq.biz/api/getChatLog" + (roomid == null ? "" : $"?room={roomid}"),
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

        public async Task<GetHistory> GetHistory(long timestamp = 0L)
        {
            return await HttpHelper.GET<GetHistory>(
                httpClient,
                "https://nasfaq.biz/api/getHistory" + (timestamp == 0L ? "" : $"?timestamp={timestamp}"),
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

        public async Task<GetLeaderboard> GetLeaderboard()
        {
            return await HttpHelper.GET<GetLeaderboard>(
                httpClient,
                "https://nasfaq.biz/api/getLeaderboard",
                headers
            );
        }

        public async Task<GetMarketInfo> GetMarketInfo()
        {
            return await HttpHelper.GET<GetMarketInfo>(
                httpClient,
                "https://nasfaq.biz/api/getMarketInfo",
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