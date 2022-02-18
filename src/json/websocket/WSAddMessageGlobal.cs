namespace Nasfaq.JSON
{
    //auctionFeed
    public class WSAddMessageGlobal : IWebsocketData
    {
        public string userid { get; set; }
        public string username { get; set; }
        public int messageid { get; set; }
        public string message { get; set; }
        public long timestamp { get; set; }
    }
}