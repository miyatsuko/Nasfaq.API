using System.Threading.Tasks;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/getFundAutoTraderRules?fund={fundid}
    public class GetFundAutoTraderRules : NasfaqResponse
    {
        public FundAutoTraderRules_Rule[] rules { get; set; }
        public int traderStatus { get; set; }
        public long timestamp { get; set; }
    }

    public class FundAutoTraderRules_Rule
    {
        public string coin { get; set; }
        public double targetQuantity { get; set; }
        public int stepQuantity { get; set; }
        public int order { get; set; }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<GetFundAutoTraderRules> GetFundAutoTraderRules(string fundid)
        {
            return await HttpHelper.GET<GetFundAutoTraderRules>(
                httpClient,
                $"https://nasfaq.biz/api/getFundAutoTraderRules?fund={fundid}",
                headers
            );
        }
    }
}