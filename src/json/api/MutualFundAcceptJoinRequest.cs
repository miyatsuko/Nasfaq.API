using System.Threading.Tasks;
using System.Text.Json;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/mutualFundAcceptJoinRequest
    public class MutualFundAcceptJoinRequest
    {
        public string fund { get; set; }
        public string pendingUser { get; set; }

        public MutualFundAcceptJoinRequest()
        {

        }

        public MutualFundAcceptJoinRequest(string fund, string pendingUser)
        {
            this.fund = fund;
            this.pendingUser = pendingUser;
        }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<NasfaqResponse> MutualFundAcceptJoinRequest(MutualFundAcceptJoinRequest data)
        {
            return await HttpHelper.POST<NasfaqResponse>(
                httpClient,
                "https://nasfaq.biz/api/mutualFundAcceptJoinRequest",
                headers,
                JsonSerializer.Serialize<MutualFundAcceptJoinRequest>(data)
            );
        }

        public async Task<NasfaqResponse> MutualFundAcceptJoinRequest(string fund, string pendingUser)
        {
            return await MutualFundAcceptJoinRequest(new MutualFundAcceptJoinRequest(fund, pendingUser));
        }
    }
}