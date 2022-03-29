namespace Nasfaq.JSON
{
    //api/getGlobalChat
    public class GetGlobalChat
    {
        public GlobalChat_Message[] chat { get; set; }
    }

    public class GlobalChat_Message
    {
        public bool IsAnonymous()
        {
            return !int.TryParse(userid, out _);
        }

        public string userid { get; set; }
        public string username { get; set ; }
        public int messageid { get; set; }
        public string message { get; set; }
        public long timestamp { get; set; }
    }
}