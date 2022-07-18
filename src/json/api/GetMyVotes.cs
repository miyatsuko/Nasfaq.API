using System.Threading.Tasks;
using Nasfaq.JSON;
using System.Collections.Generic;

namespace Nasfaq.JSON
{
    //api/getMyVotes
    public class GetMyVotes : NasfaqResponse
    {
        public Dictionary<string, int> myVotes { get; set; }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<GetMyVotes> GetMyVotes()
        {
            return await HttpHelper.GET<GetMyVotes>(
                httpClient,
                "https://nasfaq.biz/api/getMyVotes",
                headers
            );
        }
    }
}