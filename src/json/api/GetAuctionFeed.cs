using System.Threading.Tasks;
using Nasfaq.JSON;

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

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<GetAuctionFeed> GetAuctionFeed(string auctionId)
        {
            return await HttpHelper.GET<GetAuctionFeed>(
                httpClient,
                $"https://nasfaq.biz/api/getAuctionFeed?auctionid={auctionId}",
                headers
            );
        }
    }
}