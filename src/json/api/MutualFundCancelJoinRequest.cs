using System.Threading.Tasks;
using System.Text.Json;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/mutualFundCancelJoinRequest
    public class MutualFundCancelJoinRequest
    {
        public string fund { get; set; }

        public MutualFundCancelJoinRequest()
        {

        }

        public MutualFundCancelJoinRequest(string fund)
        {
            this.fund = fund;
        }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<NasfaqResponse> MutualFundCancelJoinRequest(MutualFundCancelJoinRequest data)
        {
            return await HttpHelper.POST<NasfaqResponse>(
                httpClient,
                "https://nasfaq.biz/api/mutualFundCancelJoinRequest",
                headers,
                JsonSerializer.Serialize<MutualFundCancelJoinRequest>(data)
            );
        }

        public async Task<NasfaqResponse> MutualFundCancelJoinRequest(string fund)
        {
            return await MutualFundCancelJoinRequest(new MutualFundCancelJoinRequest(fund));
        }
    }
}