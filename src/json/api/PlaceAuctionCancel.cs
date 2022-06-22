using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json;
using Nasfaq.JSON;

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

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<PlaceAuctionCancel_Response> PlaceAuctionCancel(string auctionId, string item)
        {
            return await PlaceAuctionCancel(new PlaceAuctionCancel_Request(auctionId, item));
        }

        public async Task<PlaceAuctionCancel_Response> PlaceAuctionCancel(PlaceAuctionCancel_Request cancel)
        {
            return await HttpHelper.POST<PlaceAuctionCancel_Response>(
                httpClient,
                "https://nasfaq.biz/api/placeAuctionCancel",
                headers,
                JsonSerializer.Serialize<PlaceAuctionCancel_Request>(cancel)
            );
        }

        public async Task<PlaceAuctionSell_Response> PlaceAuctionCancel(int amount, string expiration, string item, double minimumBid)
        {
            return await PlaceAuctionSell(new PlaceAuctionSell_Request(amount, expiration, item, minimumBid));
        }

        public async Task<PlaceAuctionSell_Response> PlaceAuctionCancel(int amount, int hours, int minutes, string item, double minimumBid)
        {
            return await PlaceAuctionSell(new PlaceAuctionSell_Request(amount, TimeUtils.GetAuctionString(hours, minutes), item, minimumBid));
        }
    }
}