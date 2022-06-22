using System.Threading.Tasks;
using System.Text.Json;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/deleteBettingPool
    public class DeleteBettingPool
    {
        public DeleteBettingPool()
        {

        }

        public DeleteBettingPool(string poolid)
        {
            this.poolid = poolid;
        }

        public string poolid { get; set; }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<NasfaqResponse> DeleteBettingPool(DeleteBettingPool data)
        {
            return await HttpHelper.POST<NasfaqResponse>(
                httpClient,
                "https://nasfaq.biz/api/deleteBettingPool",
                headers,
                JsonSerializer.Serialize<DeleteBettingPool>(data)
            );
        }

        public async Task<NasfaqResponse> DeleteBettingPool(string poolid)
        {
            return await DeleteBettingPool(new DeleteBettingPool(poolid));
        }
    }
}