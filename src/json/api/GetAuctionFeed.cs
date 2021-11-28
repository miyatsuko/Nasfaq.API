
namespace Nasfaq.JSON
{
    //api/getAuctionFeed?auctionid={0}
    public class GetAuctionFeed
    {
        public bool success { get; set; }
        public string auctionid { get; set; }

        public AuctionFeed_Item[] feed { get; set; }
    }

    public class AuctionFeed_Item
    {
        public long timestamp { get; set; }
        public string username { get; set; }
        public double bid { get; set; }
        public string message { get; set; }
    }
}