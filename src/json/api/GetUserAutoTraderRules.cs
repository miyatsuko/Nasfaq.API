using System.Threading.Tasks;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/getUserAutoTraderRules
    public class GetUserAutoTraderRules
    {
        public string success { get; set; }
        public UserAutoTraderRules_Rule[] rules { get; set; }
        public int traderStatus { get; set; }
        public long timestamp { get; set; }
    }

    public class UserAutoTraderRules_Rule
    {
        public string coin { get; set; }
        public int targetQuantity { get; set; }
        public int stepQuantity { get; set; }
        public int order { get; set; }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<GetUserAutoTraderRules> GetUserAutoTraderRules()
        {
            return await HttpHelper.GET<GetUserAutoTraderRules>(
                httpClient,
                "https://nasfaq.biz/api/getUserAutoTraderRules",
                headers
            );
        }
    }
}