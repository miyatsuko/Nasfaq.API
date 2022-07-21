using System.Threading.Tasks;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/getMaleEventData
    public class GetMaleEventData
    {
        public string[] usersOnMaleSide { get; set; }
        public string[] activeUsers { get; set; }
        public double malePot { get; set; }
        public double noMalePot { get; set; }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<GetMaleEventData> GetMaleEventData()
        {
            return await HttpHelper.GET<GetMaleEventData>(
                httpClient,
                "https://nasfaq.biz/api/getMaleEventData",
                headers
            );
        }
    }
}