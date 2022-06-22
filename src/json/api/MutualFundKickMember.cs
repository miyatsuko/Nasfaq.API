using System.Threading.Tasks;
using System.Text.Json;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/mutualFundKickMember
    public class MutualFundKickMember
    {
        public string fund { get; set; }
        public string removedMember { get; set; }

        public MutualFundKickMember()
        {

        }

        public MutualFundKickMember(string fund, string removedMember)
        {
            this.fund = fund;
            this.removedMember = removedMember;
        }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<NasfaqResponse> MutualFundKickMember(MutualFundKickMember data)
        {
            return await HttpHelper.POST<NasfaqResponse>(
                httpClient,
                "https://nasfaq.biz/api/mutualFundKickMember",
                headers,
                JsonSerializer.Serialize<MutualFundKickMember>(data)
            );
        }

        public async Task<NasfaqResponse> MutualFundKickMember(string fund, string removedMember)
        {
            return await MutualFundKickMember(new MutualFundKickMember(fund, removedMember));
        }
    }
}