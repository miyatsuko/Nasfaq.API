using System.Threading.Tasks;
using System.Text.Json;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/placeBet
    public class PlaceBet
    {
        public PlaceBet()
        {

        }

        public PlaceBet(string poolid, double betAmount, int option)
        {
            this.poolid = poolid;
            this.betAmount = betAmount;
            this.option = option;
        }

        public string poolid { get; set; }
        public double betAmount { get; set; }
        public int option { get; set; }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<NasfaqResponse> PlaceBet(PlaceBet data)
        {
            return await HttpHelper.POST<NasfaqResponse>(
                httpClient,
                "https://nasfaq.biz/api/placeBet",
                headers,
                JsonSerializer.Serialize<PlaceBet>(data)
            );
        }

        public async Task<NasfaqResponse> PlaceBet(string poolid, double betAmount, int option)
        {
            return await PlaceBet(new PlaceBet(poolid, betAmount, option));
        }
    }
}