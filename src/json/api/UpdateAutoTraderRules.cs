using System.Threading.Tasks;
using System.Text.Json;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/updateAutoTraderRules
    public class UpdateAutoTraderRules
    {
        public UserAutoTraderRules_Rule[] rules { get; set; }

        public UpdateAutoTraderRules()
        {

        }

        public UpdateAutoTraderRules(UserAutoTraderRules_Rule[] rules)
        {
            this.rules = rules;
        }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<string> UpdateAutoTraderRules(UpdateAutoTraderRules data)
        {
            return await HttpHelper.POST(
                httpClient,
                "https://nasfaq.biz/api/updateAutoTraderRules",
                headers,
                JsonSerializer.Serialize<UpdateAutoTraderRules>(data)
            );
        }

        public async Task<string> UpdateAutoTraderRules(UserAutoTraderRules_Rule[] rules)
        {
            return await UpdateAutoTraderRules(new UpdateAutoTraderRules(rules));
        }
    }
}