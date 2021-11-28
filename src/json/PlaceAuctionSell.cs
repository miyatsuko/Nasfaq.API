using System.Collections.Generic;

namespace Nasfaq.JSON
{
    //api/placeAuctionSell/
    public class PlaceAuctionSell_Request
    {
        public int amount { get; set; }
        public string expiration { get; set; } //"yyyy-mm-ddThh:mm:ss.000Z"
        public string item { get; set; }
        public double minimumBid { get; set; }
    }

    public class PlaceAuctionSell_Response
    {
        public bool success { get; set; }
        public string reason { get; set; }
        public Dictionary<string, UserInfo_Item[]> items { get; set; }
        public PlaceAuction_Auction auction { get; set; }
    }

    public class PlaceAuction_Auction
    {
        public string auctionID { get; set; }
        public long expiration { get; set; }
        public string item { get; set; }
        public int amount { get; set; }
        public string seller { get; set; }
        public string sellerId { get; set; }
        public string bidderId { get; set; }
        public string bidder { get; set; }
        public double currentBid { get; set; }
        public string lastOutbidid { get; set; }
        public string lastOutbid { get; set; }
        public double lastBid { get; set; }
    }
}