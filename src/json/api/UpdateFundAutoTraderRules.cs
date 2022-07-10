using System.Threading.Tasks;
using System.Text.Json;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/updateFundAutoTraderRules
    public class UpdateFundAutoTraderRules
    {
        public UpdateFundAutoTraderRules()
        {

        }

        public UpdateFundAutoTraderRules(string fund, UpdateFundAutoTraderRules_Rule[] rules)
        {
            this.fund = fund;
            this.rules = rules;
        }

        public string fund { get; set; }
        public UpdateFundAutoTraderRules_Rule[] rules { get; set; }
    }

    public class UpdateFundAutoTraderRules_Rule
    {
        public string coin { get; set; }
        public int stepQuantity { get; set; }
        public int targetQuantity { get; set; }
        public int type { get; set; }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<NasfaqResponse> UpdateFundAutoTraderRules(UpdateFundAutoTraderRules data)
        {
            return await HttpHelper.POST<NasfaqResponse>(
                httpClient,
                "https://nasfaq.biz/api/updateFundAutoTraderRules",
                headers,
                JsonSerializer.Serialize<UpdateFundAutoTraderRules>(data)
            );
        }

        public async Task<NasfaqResponse> UpdateFundAutoTraderRules(string fund, UpdateFundAutoTraderRules_Rule[] rules)
        {
            return await UpdateFundAutoTraderRules(new UpdateFundAutoTraderRules(fund, rules));
        }
    }
}