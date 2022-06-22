using System.Threading.Tasks;
using System.Text.Json;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/mutualFundPostBulletin
    public class MutualFundPostBulletin
    {
        public string fund { get; set; }
        public string message { get; set; }

        public MutualFundPostBulletin()
        {

        }

        public MutualFundPostBulletin(string fund, string message)
        {
            this.fund = fund;
            this.message = message;
        }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<NasfaqResponse> MutualFundPostBulletin(MutualFundPostBulletin data)
        {
            return await HttpHelper.POST<NasfaqResponse>(
                httpClient,
                "https://nasfaq.biz/api/mutualFundPostBulletin",
                headers,
                JsonSerializer.Serialize<MutualFundPostBulletin>(data)
            );
        }

        public async Task<NasfaqResponse> MutualFundPostBulletin(string fund, string message)
        {
            return await MutualFundPostBulletin(new MutualFundPostBulletin(fund, message));
        }
    }
}