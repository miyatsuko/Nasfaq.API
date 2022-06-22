using System.Threading.Tasks;
using System.Text.Json;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/mutualFundMakePublic
    public class MutualFundMakePublic
    {
        public string fund { get; set; }

        public MutualFundMakePublic()
        {

        }

        public MutualFundMakePublic(string fund)
        {
            this.fund = fund;
        }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<NasfaqResponse> MutualFundMakePublic(MutualFundMakePublic data)
        {
            return await HttpHelper.POST<NasfaqResponse>(
                httpClient,
                "https://nasfaq.biz/api/mutualFundMakePublic",
                headers,
                JsonSerializer.Serialize<MutualFundMakePublic>(data)
            );
        }

        public async Task<NasfaqResponse> MutualFundMakePublic(string fund)
        {
            return await MutualFundMakePublic(new MutualFundMakePublic(fund));
        }
    }
}