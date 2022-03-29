namespace Nasfaq.JSON
{
    //api/getDirectMessages?roomid={0}
    public class GetDirectMessages
    {
        public DirectMessages[] chat { get; set; }
    }

    public class DirectMessages
    {
        public string userid { get; set; }
        public string username { get; set; }
        public int messageid { get; set; }
        public string message { get; set; }
        public long timestamp { get; set; }
    }
}