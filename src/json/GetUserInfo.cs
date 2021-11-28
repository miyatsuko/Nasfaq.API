using System.Collections.Generic;

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
        public UserInfo_Muted muted { get; set; }
        public Dictionary<string, UserInfo_Item[]> items { get; set; }
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
}