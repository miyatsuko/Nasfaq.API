using System.Threading.Tasks;
using System.Text.Json;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/getMutualFundJoinRequests
    public class GetMutualFundJoinRequests_Request
    {
        public string fund { get; set; }

        public GetMutualFundJoinRequests_Request()
        {

        }

        public GetMutualFundJoinRequests_Request(string fund)
        {
            this.fund = fund;
        }
    }

    public class GetMutualFundJoinRequests_Response
    {
        public string[] requests { get; set; }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<GetMutualFundJoinRequests_Response> GetMutualFundJoinRequests(GetMutualFundJoinRequests_Request data)
        {
            return await HttpHelper.POST<GetMutualFundJoinRequests_Response>(
                httpClient,
                "https://nasfaq.biz/api/getMutualFundJoinRequests",
                headers,
                JsonSerializer.Serialize<GetMutualFundJoinRequests_Request>(data)
            );
        }

        public async Task<GetMutualFundJoinRequests_Response> GetMutualFundJoinRequests(string fund)
        {
            return await GetMutualFundJoinRequests(new GetMutualFundJoinRequests_Request(fund));
        }
    }
}