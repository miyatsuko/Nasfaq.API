using System.Threading.Tasks;
using System.Text.Json;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/toggleAutoTrader
    public class ToggleAutoTrader
    {
        public bool active { get; set; }

        public ToggleAutoTrader()
        {

        }

        public ToggleAutoTrader(bool active)
        {
            this.active = active;
        }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<string> ToggleAutoTrader(ToggleAutoTrader data)
        {
            return await HttpHelper.POST(
                httpClient,
                "https://nasfaq.biz/api/toggleAutoTrader",
                headers,
                JsonSerializer.Serialize<ToggleAutoTrader>(data)
            );
        }

        public async Task<string> ToggleAutoTrader(bool active)
        {
            return await ToggleAutoTrader(new ToggleAutoTrader(active));
        }
    }
}