using System.Collections.Generic;

namespace Nasfaq.JSON
{
    //api/getSuperchats
    public class GetSuperchats
    {
        public bool success { get; set; }
        public Dictionary<string, Superchats_Daily> daily { get; set; }
        public Dictionary<string, Superchats_History> history { get; set; }
    }

    public class Superchats_Daily
    {
        public double total { get; set; }
        public Dictionary<string, Superchat_UserTotal> userTotals { get; set; }
    }

    public class Superchat_UserTotal
    {
        public string username { get; set; }
        public double total { get; set; }
    }

    public class Superchats_History
    {
        public string coin { get; set; }
        public double total { get; set; }
        public Superchats_Superchat[] superchats { get; set; }
    }

    public class Superchats_Superchat
    {
        public string coin { get; set; }
        public string userid { get; set; }
        public string username { get; set; }
        public string usericon { get; set; }
        public long timestamp { get; set; }
        public long expiration { get; set; }
        public double amount { get; set; }
        public string message { get; set; }
    }
}