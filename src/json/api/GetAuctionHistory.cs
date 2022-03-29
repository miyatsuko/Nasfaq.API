namespace Nasfaq.JSON
{
    //api/getAuctionHistory
    public class GetAuctionHistory
    {
        public Auction_History auctionHistory { get; set; }
    }

    public class Auction_History
    {
        public string auctionID { get; set; }
        public long expiration { get; set; }
        public string item { get; set; }
        public int amount { get; set; }
        public string seller { get; set; }
        public string sellerid { get; set; }
        public string bidder { get; set; }
        public string bidderid { get; set; }
        public double currentBid { get; set; }
    }
}