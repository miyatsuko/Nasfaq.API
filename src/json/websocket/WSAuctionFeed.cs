namespace Nasfaq.JSON
{
    //auctionFeed
    public class WSAuctionFeed : IWebsocketData
    {
        public string auctionID { get; set; }
        public AuctionFeed_Item bidLog { get; set; }
        public AuctionFeed_Item messageItem { get; set; }
    }
}