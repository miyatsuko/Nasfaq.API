using System.Collections.Generic;

namespace Nasfaq.JSON
{
    //api/placeAuctionCancel/
    public class PlaceAuctionCancel_Request
    {
        public PlaceAuctionCancel_Request()
        {

        }
        
        public PlaceAuctionCancel_Request(string auctionId, string item)
        {
            this.auctionID = auctionId;
            this.item = item;
        }

        public string auctionID { get; set; }
        public string item { get; set; }
    }

    public class PlaceAuctionCancel_Response
    {
        public bool success { get; set; }
        public UserWallet wallet { get; set; }
        public Dictionary<string, UserInfo_Item[]> items { get; set; }
        public PlaceAuction_Auction auction { get; set; }
    }
}