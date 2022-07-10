using System.Threading.Tasks;
using System.Text.Json;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/toggleFundAutoTrader
    public class ToggleFundAutoTrader
    {
        public ToggleFundAutoTrader()
        {

        }

        public ToggleFundAutoTrader(bool active, string fund)
        {
            this.active = active;
            this.fund = fund;
        }

        public bool active { get; set; }
        public string fund { get; set; }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<NasfaqResponse> ToggleFundAutoTrader(ToggleFundAutoTrader data)
        {
            return await HttpHelper.POST<NasfaqResponse>(
                httpClient,
                "https://nasfaq.biz/api/toggleFundAutoTrader",
                headers,
                JsonSerializer.Serialize<ToggleFundAutoTrader>(data)
            );
        }

        public async Task<NasfaqResponse> ToggleFundAutoTrader(bool active, string fund)
        {
            return await ToggleFundAutoTrader(new ToggleFundAutoTrader(active, fund));
        }
    }
}