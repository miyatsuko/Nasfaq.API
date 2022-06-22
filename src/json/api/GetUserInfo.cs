using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using System.Text.Json;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/getUserInfo
    public class GetUserInfo
    {
        public bool loggedout { get; set; }
        public string username { get; set; }
        public string id { get; set; }
        public string email  { get; set; }
        public UserInfo_PerformanceTick[] performance { get; set; }
        public bool verified { get; set; }
        public UserWallet wallet { get; set; }
        public string icon { get; set; }
        public bool admin { get; set; }
        public UserInfo_Settings settings { get; set; }
        public string color { get; set; }
        public string hat { get; set; }
        public UserInfo_Muted muted { get; set; }
        public Dictionary<string, UserInfo_Item[]> items { get; set; }
        public double taxCredits { get; set; }
        public bool isBookie { get; set; }
        public string[] usersBlocking { get; set; }
        public string[] usersBlockedBy { get; set; }
        public UserInfo_DirectMessages[] directMessages { get; set; }
        public string socketid { get; set; }
        public double brokerFeeTotal { get; set; }
        public string[] userMutualFundJoinRequests { get; set; }
        public UserInfo_FundOrder[] mutualfundOrders { get; set; }
        public Dictionary<string, UserInfo_UserMutualFunds> userMutualFunds { get; set; }
    }

    //api/updateSettings
    public class UserInfo_Settings
    {
        public bool walletIsPublic { get; set; }
    }

    public class UserInfo_PerformanceTick
    {
        public long timestamp { get; set; }
        public double worth { get; set; }
    }

    public class UserInfo_Muted
    {
        public bool muted { get; set; }
        public long until { get; set; }
        public string message { get; set; }
    }

    public class UserInfo_Item
    {
        public string itemType { get; set; }
        public long acquiredTimestamp { get; set; }
        public double lastPurchasePrice { get; set; }
        public int quantity { get; set; }
    }

    public class UserInfo_DirectMessages
    {
        public string roomid { get; set; }
        public string user1 { get; set; }
        public string user2 { get; set; }
        public string user1name { get; set; }
        public string user2name { get; set; }
        public string preview { get; set; }
        public long timestamp { get; set; }
    }

    public class UserInfo_FundOrder
    {
        public string fundid { get; set; }
        public int quantity { get; set; }
    }

    public class UserInfo_UserMutualFunds
    {
        public string name { get; set; }
        public string icon { get; set; }
        public int amt { get; set; }
        public long timestamp { get; set; }
        public double meanPurchasePrice { get; set; }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<GetUserInfo> GetUserInfo()
        {
            string json = await HttpHelper.GET(
                httpClient,
                "https://nasfaq.biz/api/getUserInfo",
                headers
            );

            JsonDocument jsonDocument = JsonDocument.Parse(json);
            JsonElement root = jsonDocument.RootElement;

            if(root.TryGetProperty("loggedout", out JsonElement isLoggedOut))
            {
                if(isLoggedOut.GetBoolean())
                {
                    throw new LoggedOutException();
                }
            }

            GetUserInfo getUserInfo = new GetUserInfo();
            getUserInfo.loggedout = root.GetProperty("loggedout").GetBoolean();
            getUserInfo.username = root.GetProperty("username").GetString();
            getUserInfo.id = root.GetProperty("id").GetString();
            getUserInfo.email = root.GetProperty("email").GetString();
            {
                JsonElement perfArray = root.GetProperty("performance");
                getUserInfo.performance = new UserInfo_PerformanceTick[perfArray.GetArrayLength()];
                for(int i = 0; i < getUserInfo.performance.Length; i++)
                {
                    double worth = 0.0;
                    try
                    {
                        worth = Convert.ToDouble(perfArray[i].GetProperty("worth").GetString(), CultureInfo.InvariantCulture);
                    }
                    catch
                    {
                        worth = 0.0;
                        Console.WriteLine($"WARNING: field \"worth\" was [{perfArray[i].GetProperty("worth").GetRawText()}]");
                    }

                    getUserInfo.performance[i] = new UserInfo_PerformanceTick()
                    {
                        worth = worth,
                        timestamp = perfArray[i].GetProperty("timestamp").GetInt64()
                    };
                }
            }
            getUserInfo.verified = root.GetProperty("verified").GetBoolean();
            getUserInfo.wallet = JsonSerializer.Deserialize<UserWallet>(root.GetProperty("wallet").GetString());
            getUserInfo.icon = root.GetProperty("icon").GetString();
            getUserInfo.admin = root.GetProperty("admin").GetBoolean();
            getUserInfo.settings = JsonSerializer.Deserialize<UserInfo_Settings>(root.GetProperty("settings").GetString());
            getUserInfo.color = root.GetProperty("color").GetString();
            getUserInfo.hat = root.GetProperty("hat").GetString();
            getUserInfo.muted = JsonSerializer.Deserialize<UserInfo_Muted>(root.GetProperty("muted").GetString());
            getUserInfo.items = JsonSerializer.Deserialize<Dictionary<string, UserInfo_Item[]>>(root.GetProperty("items").GetString());
            getUserInfo.taxCredits = root.GetProperty("taxCredits").GetDouble();
            {
                JsonElement usersBlockingArray = root.GetProperty("usersBlocking");
                getUserInfo.usersBlocking = new string[usersBlockingArray.GetArrayLength()];
                for(int i = 0; i < getUserInfo.usersBlocking.Length; i++)
                {
                    getUserInfo.usersBlocking[i] = usersBlockingArray[i].GetString();
                }
            }
            {
                JsonElement usersBlockedArray = root.GetProperty("usersBlockedBy");
                getUserInfo.usersBlockedBy = new string[usersBlockedArray.GetArrayLength()];
                for(int i = 0; i < getUserInfo.usersBlockedBy.Length; i++)
                {
                    getUserInfo.usersBlockedBy[i] = usersBlockedArray[i].GetString();
                }
            }
            {
                JsonElement dmArray = root.GetProperty("directMessages");
                getUserInfo.directMessages = new UserInfo_DirectMessages[dmArray.GetArrayLength()];
                for(int i = 0; i < getUserInfo.directMessages.Length; i++)
                {
                    getUserInfo.directMessages[i] = new UserInfo_DirectMessages()
                    {
                        roomid = dmArray[i].GetProperty("roomid").GetString(),
                        user1 = dmArray[i].GetProperty("user1").GetString(),
                        user2 = dmArray[i].GetProperty("user2").GetString(),
                        user1name = dmArray[i].GetProperty("user1name").GetString(),
                        user2name = dmArray[i].GetProperty("user2name").GetString(),
                        preview = dmArray[i].GetProperty("preview").GetString(),
                        timestamp = dmArray[i].GetProperty("timestamp").GetInt64()
                    };
                }
            }
            getUserInfo.socketid = root.GetProperty("socketid").GetString();
            getUserInfo.brokerFeeTotal = root.GetProperty("brokerFeeTotal").GetDouble();
            {
                JsonElement userMutualFundJoinRequests = root.GetProperty("userMutualFundJoinRequests");
                getUserInfo.userMutualFundJoinRequests = new string[userMutualFundJoinRequests.GetArrayLength()];
                for(int i = 0; i < getUserInfo.userMutualFundJoinRequests.Length; i++)
                {
                    getUserInfo.userMutualFundJoinRequests[i] = userMutualFundJoinRequests[i].GetString();
                }
            }
            getUserInfo.mutualfundOrders = JsonSerializer.Deserialize<UserInfo_FundOrder[]>(root.GetProperty("mutualfundOrders").GetRawText());
            getUserInfo.userMutualFunds = JsonSerializer.Deserialize<Dictionary<string, UserInfo_UserMutualFunds>>(root.GetProperty("userMutualFunds").GetRawText());
            return getUserInfo;
        }
    }
}