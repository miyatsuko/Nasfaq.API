namespace Nasfaq.JSON
{
    //api/placeAuctionBid/
    public class PlaceAuctionBid_Request
    {
        public string auctionID { get; set; }
        public double currentBid { get; set; }
        public string item { get; set; }
    }
    
    public class PlaceAuctionBid_Response
    {
        public bool success { get; set; }
        public string response { get; set; }
        public PlaceAuction_Auction auction { get; set; }
        public UserWallet wallet { get; set; }
    }
}