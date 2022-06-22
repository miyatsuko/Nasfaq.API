using System.Threading.Tasks;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/getAuctionCurrent
    public class GetAuctionCurrent
    {
        public Auction[] auctions { get; set; }
    }

    public class Auction
    {
        public string acutionID { get; set; }
        public long expiration { get; set; }
        public string item { get; set; }
        public int amount { get; set; }
        public string seller { get; set; }
        public string sellerid { get; set; }
        public string bidder { get; set; }
        public string bidderid { get; set; }
        public double currentBid { get; set; }
        public string lastOutbid { get; set; }
        public string lastOutbidid { get; set; }
        public double lastBid { get; set; }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<GetAuctionCurrent> GetAuctionCurrent()
        {
            return await HttpHelper.GET<GetAuctionCurrent>(
                httpClient,
                "https://nasfaq.biz/api/getAuctionCurrent",
                headers
            );
        }
    }
}