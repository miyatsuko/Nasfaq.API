using System.Threading.Tasks;
using System.Text.Json;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/archiveBettingPool
    public class ArchiveBettingPool
    {
        public ArchiveBettingPool()
        {

        }

        public ArchiveBettingPool(string poolid)
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
        public async Task<NasfaqResponse> ArchiveBettingPool(ArchiveBettingPool data)
        {
            return await HttpHelper.POST<NasfaqResponse>(
                httpClient,
                "https://nasfaq.biz/api/archiveBettingPool",
                headers,
                JsonSerializer.Serialize<ArchiveBettingPool>(data)
            );
        }

        public async Task<NasfaqResponse> ArchiveBettingPool(string poolid)
        {
            return await ArchiveBettingPool(new ArchiveBettingPool(poolid));
        }
    }
}