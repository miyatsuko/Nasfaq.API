using System.Threading.Tasks;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/getMarketSwitch
    public class GetMarketSwitch
    {
        public bool success { get; set; }
        public bool marketSwitch { get; set; }
    }    
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<GetMarketSwitch> GetMarketSwitch()
        {
            return await HttpHelper.GET<GetMarketSwitch>(
                httpClient,
                "https://nasfaq.biz/api/getMarketSwitch",
                headers
            );
        }
    }
}