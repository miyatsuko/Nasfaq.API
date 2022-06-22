using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/placeAuctionBid/
    public class PlaceAuctionBid_Request
    {
        public PlaceAuctionBid_Request()
        {

        }
        
        public PlaceAuctionBid_Request(string auctionId, double bid, string item)
        {
            this.auctionID = auctionId;
            this.currentBid = bid;
            this.item = item;
        }

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

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<PlaceAuctionBid_Response> PlaceAuctionBid(string auctionId, double bid, string item)
        {
            return await PlaceAuctionBid(new PlaceAuctionBid_Request(auctionId, bid, item));
        }

        public async Task<PlaceAuctionBid_Response> PlaceAuctionBid(PlaceAuctionBid_Request bid)
        {
            return await HttpHelper.POST<PlaceAuctionBid_Response>(
                httpClient,
                "https://nasfaq.biz/api/placeAuctionBid",
                headers,
                JsonSerializer.Serialize<PlaceAuctionBid_Request>(bid)
            );
        }
    }
}