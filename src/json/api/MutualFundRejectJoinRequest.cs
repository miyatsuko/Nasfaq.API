using System.Threading.Tasks;
using System.Text.Json;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/mutualFundRejectJoinRequest
    public class MutualFundRejectJoinRequest
    {
        public string fund { get; set; }
        public string rejectedUser { get; set; }

        public MutualFundRejectJoinRequest()
        {

        }

        public MutualFundRejectJoinRequest(string fund, string rejectedUser)
        {
            this.fund = fund;
            this.rejectedUser = rejectedUser;
        }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<NasfaqResponse> MutualFundRejectJoinRequest(MutualFundRejectJoinRequest data)
        {
            return await HttpHelper.POST<NasfaqResponse>(
                httpClient,
                "https://nasfaq.biz/api/mutualFundRejectJoinRequest",
                headers,
                JsonSerializer.Serialize<MutualFundRejectJoinRequest>(data)
            );
        }

        public async Task<NasfaqResponse> MutualFundRejectJoinRequest(string fund, string rejectedUser)
        {
            return await MutualFundRejectJoinRequest(new MutualFundRejectJoinRequest(fund, rejectedUser));
        }
    }
}