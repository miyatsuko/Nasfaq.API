using System.Threading.Tasks;
using System.Text.Json;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/deleteAuctionAdmin
    public class DeleteAuctionAdmin
    {
        public DeleteAuctionAdmin(){}
        public DeleteAuctionAdmin(string auctionid)
        {
            this.auctionid = auctionid;
        }

        public string auctionid { get; set; }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<NasfaqResponse> DeleteAuctionAdmin(DeleteAuctionAdmin data)
        {
            return await HttpHelper.POST<NasfaqResponse>(
                httpClient,
                "https://nasfaq.biz/api/deleteAuctionAdmin",
                headers,
                JsonSerializer.Serialize<DeleteAuctionAdmin>(data)
            );
        }

        public async Task<NasfaqResponse> DeleteAuctionAdmin(string auctionid)
        {
            return await DeleteAuctionAdmin(new DeleteAuctionAdmin(auctionid));
        }
    }
}