using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/placeAuctionSell/
    public class PlaceAuctionSell_Request
    {
        public PlaceAuctionSell_Request()
        {

        }

        public PlaceAuctionSell_Request(int amount, string expiration, string item, double minimumBid)
        {
            this.amount = amount;
            this.expiration = expiration;
            this.item = item;
            this.minimumBid = minimumBid;
        }

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
        public string sellerid { get; set; }
        public string bidderid { get; set; }
        public string bidder { get; set; }
        public double currentBid { get; set; }
        public string lastOutbidid { get; set; }
        public string lastOutbid { get; set; }
        public double lastBid { get; set; }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<PlaceAuctionSell_Response> PlaceAuctionSell(PlaceAuctionSell_Request sell)
        {
            return await HttpHelper.POST<PlaceAuctionSell_Response>(
                httpClient,
                "https://nasfaq.biz/api/placeAuctionSell",
                headers,
                JsonSerializer.Serialize<PlaceAuctionSell_Request>(sell)
            );
        }
    }
}