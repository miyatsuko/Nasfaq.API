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

        public async Task<NasfaqResponse> AddChatBlock(AddChatBlock data)
        {
            return await HttpHelper.POST<NasfaqResponse>(
                httpClient,
                "https://nasfaq.biz/api/addChatBlock",
                headers,
                JsonSerializer.Serialize<AddChatBlock>(data)
            );
        }

        public async Task<NasfaqResponse> AddChatBlock(string blockedPlayer)
        {
            return await AddChatBlock(new AddChatBlock(blockedPlayer));
        }

        public async Task<NasfaqResponse> AddChatDM(AddChatDM data)
        {
            return await HttpHelper.POST<NasfaqResponse>(
                httpClient,
                "https://nasfaq.biz/api/addChatDM",
                headers,
                JsonSerializer.Serialize<AddChatDM>(data)
            );
        }

        public async Task<NasfaqResponse> AddChatDM(string message, string receiver_id)
        {
            return await AddChatDM(new AddChatDM(message, receiver_id));
        }

        public async Task<NasfaqResponse> AddChatGlobal(AddChatGlobal data)
        {
            return await HttpHelper.POST<NasfaqResponse>(
                httpClient,
                "https://nasfaq.biz/api/addChatGlobal",
                headers,
                JsonSerializer.Serialize<AddChatGlobal>(data)
            );
        }

        public async Task<NasfaqResponse> AddChatGlobal(string message, bool anonymous)
        {
            return await AddChatGlobal(new AddChatGlobal(message, anonymous));
        }

        public async Task<NasfaqResponse> AddChatReport(AddChatReport data)
        {
            return await HttpHelper.POST<NasfaqResponse>(
                httpClient,
                "https://nasfaq.biz/api/addChatReport",
                headers,
                JsonSerializer.Serialize<AddChatReport>(data)
            );
        }

        public async Task<NasfaqResponse> AddChatReport(string messageid)
        {
            return await AddChatReport(new AddChatReport(messageid));
        }

        public async Task<NasfaqResponse> AddMessage(AddMessage data)
        {
            return await HttpHelper.POST<NasfaqResponse>(
                httpClient,
                "https://nasfaq.biz/api/addMessage",
                headers,
                JsonSerializer.Serialize<AddMessage>(data)
            );
        }

        public async Task<NasfaqResponse> AddMessage(string room, string text)
        {
            return await AddMessage(new AddMessage(room, text));
        }

        public async Task<NasfaqResponse> AddReport(AddReport data)
        {
            return await HttpHelper.POST<NasfaqResponse>(
                httpClient,
                "https://nasfaq.biz/api/addReport",
                headers,
                JsonSerializer.Serialize<AddReport>(data)
            );
        }

        public async Task<NasfaqResponse> AddReport(int id, string roomId, string text, long timestamp, string username)
        {
            return await AddReport(new AddReport(id, roomId, text, timestamp, username));
        }

        public async Task<NasfaqResponse> AddRoom(AddRoom data)
        {
            return await HttpHelper.POST<NasfaqResponse>(
                httpClient,
                "https://nasfaq.biz/api/addRoom",
                headers,
                JsonSerializer.Serialize<AddRoom>(data)
            );
        }

        public async Task<NasfaqResponse> AddRoom(string subject, string openingText)
        {
            return await AddRoom(new AddRoom(subject, openingText));
        }

        public async Task<NasfaqResponse> ArchiveBettingPool(ArchiveBettingPool data)
        {
            return await HttpHelper.POST<NasfaqResponse>(
                httpClient,
                "https://nasfaq.biz/api/archiveBettingPool",
                headers,
                JsonSerializer.Serialize<ArchiveBettingPool>(data)
            );
        }

        public async Task<NasfaqResponse> ArchiveBettingPool(string poolid)
        {
            return await ArchiveBettingPool(new ArchiveBettingPool(poolid));
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

        public async Task<string> BuySuperchat(double amount, string coin, string message)
        {
            return await BuySuperchat(new BuySuperchat(amount, coin, message));
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

        public async Task<string> ChangeEmail(string email)
        {
            return await ChangeEmail(new ChangeEmail(email));
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

        public async Task<string> ChangeUsername(string username)
        {
            return await ChangeUsername(new ChangeUsername(username));
        }

        public async Task<NasfaqResponse> CraftItem(string[] items)
        {
            return await HttpHelper.POST<NasfaqResponse>(
                httpClient,
                "https://nasfaq.biz/api/craftItem",
                headers,
                JsonSerializer.Serialize<CraftItem>(new CraftItem() { items = items})
            );
        }

        public async Task<NasfaqResponse> CreateBettingPool(CreateBettingPool data)
        {
            return await HttpHelper.POST<NasfaqResponse>(
                httpClient,
                "https://nasfaq.biz/api/createBettingPool",
                headers,
                JsonSerializer.Serialize<CreateBettingPool>(data)
            );
        }

        public async Task<NasfaqResponse> CreateBettingPool(string topic, string[] options, long closingTime)
        {
            return await CreateBettingPool(new CreateBettingPool(topic, options, closingTime));
        }

        public async Task<NasfaqResponse> CreateDM(CreateDM data)
        {
            return await HttpHelper.POST<NasfaqResponse>(
                httpClient,
                "https://nasfaq.biz/api/createDM",
                headers,
                JsonSerializer.Serialize<CreateDM>(data)
            );
        }

        public async Task<NasfaqResponse> CreateDM(string message, string receiver_username)
        {
            return await CreateDM(new CreateDM(message, receiver_username));
        }

        public async Task<NasfaqResponse> DeleteAuctionAdmin(DeleteAuctionAdmin data)
        {
            return await HttpHelper.POST<NasfaqResponse>(
                httpClient,
                "https://nasfaq.biz/api/deleteAuctionAdmin",
                headers,
                JsonSerializer.Serialize<DeleteAuctionAdmin>(data)
            );
        }

        public async Task<NasfaqResponse> DeleteAuctionAdmin(string auctionid)
        {
            return await DeleteAuctionAdmin(new DeleteAuctionAdmin(auctionid));
        }

        public async Task<NasfaqResponse> DeleteBettingPool(DeleteBettingPool data)
        {
            return await HttpHelper.POST<NasfaqResponse>(
                httpClient,
                "https://nasfaq.biz/api/deleteBettingPool",
                headers,
                JsonSerializer.Serialize<DeleteBettingPool>(data)
            );
        }

        public async Task<NasfaqResponse> DeleteBettingPool(string poolid)
        {
            return await DeleteBettingPool(new DeleteBettingPool(poolid));
        }

        public async Task<NasfaqResponse> DeleteOwnAccount(DeleteOwnAccount data)
        {
            return await HttpHelper.POST<NasfaqResponse>(
                httpClient,
                "https://nasfaq.biz/api/deleteOwnAccount",
                headers,
                JsonSerializer.Serialize<DeleteOwnAccount>(data)
            );
        }

        public async Task<NasfaqResponse> DeleteOwnAccount(string password)
        {
            return await DeleteOwnAccount(new DeleteOwnAccount(password));
        }

        public async Task<DestroySession> DestroySession()
        {
            return await HttpHelper.GET<DestroySession>(
                httpClient,
                "https://nasfaq.biz/api/destroySession",
                headers
            );
        }

        public async Task<NasfaqResponse> FindEgg(FindEgg egg)
        {
            return await HttpHelper.POST<NasfaqResponse>(
                httpClient,
                "https://nasfaq.biz/api/findEgg",
                headers,
                JsonSerializer.Serialize(egg)
            );
        }

        public async Task<NasfaqResponse> FindEgg(string eggid)
        {
            return await HttpHelper.POST<NasfaqResponse>(
                httpClient,
                "https://nasfaq.biz/api/findEgg",
                headers,
                JsonSerializer.Serialize(new FindEgg(eggid))
            );
        }

        public async Task<GetAdmins> GetAdmins()
        {
            return await HttpHelper.GET<GetAdmins>(
                httpClient,
                "https://nasfaq.biz/api/getAdmins",
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

        public async Task<GetAuctionCurrent> GetAuctionCurrent()
        {
            return await HttpHelper.GET<GetAuctionCurrent>(
                httpClient,
                "https://nasfaq.biz/api/getAuctionCurrent",
                headers
            );
        }

        public async Task<GetAuctionFeed> GetAuctionFeed(string auctionId)
        {
            return await HttpHelper.GET<GetAuctionFeed>(
                httpClient,
                $"https://nasfaq.biz/api/getAuctionFeed?auctionid={auctionId}",
                headers
            );
        }

        public async Task<GetAuctionHistory> GetAuctionHistory()
        {
            return await HttpHelper.GET<GetAuctionHistory>(
                httpClient,
                $"https://nasfaq.biz/api/getAuctionHistory",
                headers
            );
        }

        public async Task<GetBenchmarkInfo> GetBenchmarkInfo()
        {
            return await HttpHelper.GET<GetBenchmarkInfo>(
                httpClient,
                $"https://nasfaq.biz/api/getBenchmarkInfo",
                headers
            );
        }

        public async Task<GetBenchmarkLeaderboard> GetBenchmarkLeaderboard()
        {
            return await HttpHelper.GET<GetBenchmarkLeaderboard>(
                httpClient,
                $"https://nasfaq.biz/api/getBenchmarkLeaderboard",
                headers
            );
        }

        public async Task<GetBettingPools> GetBettingPools()
        {
            return await HttpHelper.GET<GetBettingPools>(
                httpClient,
                $"https://nasfaq.biz/api/getBettingPools",
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

        public async Task<GetDirectMessages> GetDirectMessages(string roomid)
        {
            return await HttpHelper.GET<GetDirectMessages>(
                httpClient,
                $"https://nasfaq.biz/api/getDirectMessages?roomid={roomid}",
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

        public async Task<GetGlobalChat> GetGlobalChat()
        {
            return await HttpHelper.GET<GetGlobalChat>(
                httpClient,
                "https://nasfaq.biz/api/getGlobalChat",
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

        public async Task<GetItemMarketPrices> GetItemMarketPrices()
        {
            return await HttpHelper.GET<GetItemMarketPrices>(
                httpClient,
                "https://nasfaq.biz/api/getItemMarketPrices",
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

        public async Task<GetMarketSwitch> GetMarketSwitch()
        {
            return await HttpHelper.GET<GetMarketSwitch>(
                httpClient,
                "https://nasfaq.biz/api/getMarketSwitch",
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
            string json = await HttpHelper.GET(
                httpClient,
                "https://nasfaq.biz/api/getStats",
                headers
            );
            
            GetStats getStats = new GetStats();
            getStats.stats = new System.Collections.Generic.Dictionary<string, Stats>();
            JsonDocument jsonDocument = JsonDocument.Parse(json);
            JsonElement stats = jsonDocument.RootElement.GetProperty("stats");
            foreach(JsonProperty kvp in stats.EnumerateObject())
            {
                Stats statsObject = new Stats();
                for(int j = 0; j < 6; j++)
                {
                    JsonElement element = default;
                    if(j == 0) element = kvp.Value.GetProperty("subscriberCount");
                    else if(j == 1) element = kvp.Value.GetProperty("dailySubscriberCount");
                    else if(j == 2) element = kvp.Value.GetProperty("weeklySubscriberCount");
                    else if(j == 3) element = kvp.Value.GetProperty("viewCount");
                    else if(j == 4) element = kvp.Value.GetProperty("dailyViewCount");
                    else if(j == 5) element = kvp.Value.GetProperty("weeklyViewCount");

                    JsonElement nameElement = element.GetProperty("name");
                    JsonElement labelsElement = element.GetProperty("labels");
                    JsonElement dataElement = element.GetProperty("data");

                    Stats_Data data = new Stats_Data();
                    data.name = nameElement.ToString();
                    data.labels = new string[labelsElement.GetArrayLength()];
                    data.data = new int[dataElement.GetArrayLength()];

                    int i = 0;
                    foreach(JsonElement value in labelsElement.EnumerateArray())
                    {
                        data.labels[i] = value.ToString();
                        i++;
                    }

                    i = 0;
                    foreach(JsonElement value in dataElement.EnumerateArray())
                    {
                        if(value.ValueKind == JsonValueKind.String)
                        {
                            data.data[i] = Int32.Parse(value.GetString());
                        }
                        else
                        {
                            data.data[i] = value.GetInt32();
                        }
                        i++;
                    }

                    if(j == 0) statsObject.subscriberCount = data;
                    else if(j == 1) statsObject.dailySubscriberCount = data;
                    else if(j == 2) statsObject.weeklySubscriberCount = data;
                    else if(j == 3) statsObject.viewCount = data;
                    else if(j == 4) statsObject.dailyViewCount = data;
                    else if(j == 5) statsObject.weeklyViewCount = data;
                }
                getStats.stats.Add(kvp.Name, statsObject);
            }

            JsonElement coinHistory = jsonDocument.RootElement.GetProperty("coinHistory");
            getStats.coinHistory = JsonSerializer.Deserialize<Stats_CoinHistory[]>(coinHistory.ToString());


            return getStats;
        }

        public async Task<GetSuperchats> GetSuperchats()
        {
            return await HttpHelper.GET<GetSuperchats>(
                httpClient,
                "https://nasfaq.biz/api/getSuperchats",
                headers
            );
        }

        public async Task<GetUserAutoTraderRules> GetUserAutoTraderRules()
        {
            return await HttpHelper.GET<GetUserAutoTraderRules>(
                httpClient,
                "https://nasfaq.biz/api/getUserAutoTraderRules",
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

        public async Task<PlaceAuctionBid_Response> PlaceAuctionBid(string auctionId, double bid, string item)
        {
            return await PlaceAuctionBid(new PlaceAuctionBid_Request(auctionId, bid, item));
        }

        public async Task<PlaceAuctionBid_Response> PlaceAuctionBid(PlaceAuctionBid_Request bid)
        {
            return await HttpHelper.POST<PlaceAuctionBid_Response>(
                httpClient,
                "https://nasfaq.biz/api/placeAuctionBid",
                headers,
                JsonSerializer.Serialize<PlaceAuctionBid_Request>(bid)
            );
        }

        public async Task<PlaceAuctionCancel_Response> PlaceAuctionCancel(string auctionId, string item)
        {
            return await PlaceAuctionCancel(new PlaceAuctionCancel_Request(auctionId, item));
        }

        public async Task<PlaceAuctionCancel_Response> PlaceAuctionCancel(PlaceAuctionCancel_Request cancel)
        {
            return await HttpHelper.POST<PlaceAuctionCancel_Response>(
                httpClient,
                "https://nasfaq.biz/api/placeAuctionCancel",
                headers,
                JsonSerializer.Serialize<PlaceAuctionCancel_Request>(cancel)
            );
        }

        public async Task<PlaceAuctionSell_Response> PlaceAuctionCancel(int amount, string expiration, string item, double minimumBid)
        {
            return await PlaceAuctionSell(new PlaceAuctionSell_Request(amount, expiration, item, minimumBid));
        }

        public async Task<PlaceAuctionSell_Response> PlaceAuctionCancel(int amount, int hours, int minutes, string item, double minimumBid)
        {
            return await PlaceAuctionSell(new PlaceAuctionSell_Request(amount, TimeUtils.GetAuctionString(hours, minutes), item, minimumBid));
        }

        public async Task<PlaceAuctionSell_Response> PlaceAuctionSell(PlaceAuctionSell_Request sell)
        {
            return await HttpHelper.POST<PlaceAuctionSell_Response>(
                httpClient,
                "https://nasfaq.biz/api/placeAuctionSell",
                headers,
                JsonSerializer.Serialize<PlaceAuctionSell_Request>(sell)
            );
        }

        public async Task<NasfaqResponse> PlaceBet(PlaceBet data)
        {
            return await HttpHelper.POST<NasfaqResponse>(
                httpClient,
                "https://nasfaq.biz/api/placeBet",
                headers,
                JsonSerializer.Serialize<PlaceBet>(data)
            );
        }

        public async Task<NasfaqResponse> PlaceBet(string poolid, double betAmount, int option)
        {
            return await PlaceBet(new PlaceBet(poolid, betAmount, option));
        }

        public async Task<NasfaqResponse> RefundBets(RefundBets data)
        {
            return await HttpHelper.POST<NasfaqResponse>(
                httpClient,
                "https://nasfaq.biz/api/refundBets",
                headers,
                JsonSerializer.Serialize<RefundBets>(data)
            );
        }

        public async Task<NasfaqResponse> RefundBets(string poolid)
        {
            return await RefundBets(new RefundBets(poolid));
        }

        public async Task<NasfaqResponse> RemoveChatBlock(RemoveChatBlock data)
        {
            return await HttpHelper.POST<NasfaqResponse>(
                httpClient,
                "https://nasfaq.biz/api/removeChatBlock",
                headers,
                JsonSerializer.Serialize<RemoveChatBlock>(data)
            );
        }

        public async Task<NasfaqResponse> RemoveChatBlock(string blocked)
        {
            return await RemoveChatBlock(new RemoveChatBlock(blocked));
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

        public async Task<string> RollGacha(int bulk)
        {
            return await RollGacha(new RollGacha(bulk));
        }

        public async Task<SendAuctionMessage_Response> SendAuctionMessage(SendAuctionMessage_Request message)
        {
            return await HttpHelper.POST<SendAuctionMessage_Response>(
                httpClient,
                "https://nasfaq.biz/api/sendAuctionMessage",
                headers,
                JsonSerializer.Serialize<SendAuctionMessage_Request>(message)
            );
        }

        public async Task<SendAuctionMessage_Response> SendAuctionMessage(string auctionId, string message)
        {
            return await SendAuctionMessage(new SendAuctionMessage_Request(auctionId, message));
        }

        public async Task<NasfaqResponse> SetBettingPoolOptionStatus(SetBettingPoolOptionStatus message)
        {
            return await HttpHelper.POST<NasfaqResponse>(
                httpClient,
                "https://nasfaq.biz/api/setBettingPoolOpenStatus",
                headers,
                JsonSerializer.Serialize<SetBettingPoolOptionStatus>(message)
            );
        }

        public async Task<NasfaqResponse> SetBettingPoolOptionStatus(string poolid, bool openStatus)
        {
            return await SetBettingPoolOptionStatus(new SetBettingPoolOptionStatus(poolid, openStatus));
        }

        public async Task<NasfaqResponse> SetBettingPoolWinner(SetBettingPoolWinner message)
        {
            return await HttpHelper.POST<NasfaqResponse>(
                httpClient,
                "https://nasfaq.biz/api/setBettingPoolWinner",
                headers,
                JsonSerializer.Serialize<SetBettingPoolWinner>(message)
            );
        }

        public async Task<NasfaqResponse> SetBettingPoolWinner(string poolid, int winOption)
        {
            return await SetBettingPoolWinner(new SetBettingPoolWinner(poolid, winOption));
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

        public async Task<string> SetIcon(string icon)
        {
            return await SetIcon(new SetIcon(icon));
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

        public async Task<string> SetUserLeaderboardColor(string color)
        {
            return await SetUserLeaderboardColor(new SetUserLeaderboardColor(color));
        }
        
        public async Task<string> SetUserLeaderboardHat(SetUserLeaderboardHat data)
        {
            return await HttpHelper.POST(
                httpClient,
                "https://nasfaq.biz/api/setUserLeaderboardHat",
                headers,
                JsonSerializer.Serialize<SetUserLeaderboardHat>(data)
            );
        }

        public async Task<string> SetUserLeaderboardHat(string hat)
        {
            return await SetUserLeaderboardHat(new SetUserLeaderboardHat(hat));
        }

        public async Task<string> ToggleAutoTrader(ToggleAutoTrader data)
        {
            return await HttpHelper.POST(
                httpClient,
                "https://nasfaq.biz/api/toggleAutoTrader",
                headers,
                JsonSerializer.Serialize<ToggleAutoTrader>(data)
            );
        }

        public async Task<string> ToggleAutoTrader(bool active)
        {
            return await ToggleAutoTrader(new ToggleAutoTrader(active));
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

        public async Task<string> Trade(string coin, TradeType type)
        {
            return await Trade(new Trade(coin, type));
        }

        public async Task<string> Trade(string coin, int quantity, TradeType type)
        {
            return await Trade(new Trade(coin, quantity, type));
        }

        public async Task<string> Trade(string[] buys, string[] sells)
        {
            return await Trade(new Trade(buys, sells));
        }

        public async Task<string> Trade((string, int)[] buys, (string, int)[] sells)
        {
            return await Trade(new Trade(buys, sells));
        }

        public async Task<string> Trade(Trade_Coin[] orders)
        {
            return await Trade(new Trade(orders));
        }
        
        public async Task<NasfaqResponse> VerifyEmail(VerifyEmail data)
        {
            return await HttpHelper.POST<NasfaqResponse>(
                httpClient,
                "https://nasfaq.biz/api/verifyEmail",
                headers,
                JsonSerializer.Serialize<VerifyEmail>(data)
            );
        }

        public async Task<string> UpdateAutoTraderRules(UpdateAutoTraderRules data)
        {
            return await HttpHelper.POST(
                httpClient,
                "https://nasfaq.biz/api/updateAutoTraderRules",
                headers,
                JsonSerializer.Serialize<UpdateAutoTraderRules>(data)
            );
        }

        public async Task<string> UpdateAutoTraderRules(UserAutoTraderRules_Rule[] rules)
        {
            return await UpdateAutoTraderRules(new UpdateAutoTraderRules(rules));
        }

        public async Task<NasfaqResponse> VerifyEmail(string userid, string key)
        {
            return await VerifyEmail(new VerifyEmail(userid, key));
        }
    }
}
