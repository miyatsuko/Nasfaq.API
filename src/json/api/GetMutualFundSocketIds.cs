using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json;
using Nasfaq.JSON;

//api/getMutualFundSocketIds
namespace Nasfaq.JSON
{
    public class GetMutualFundSocketIds_Request
    {
        public string[] funds { get; set; }

        public GetMutualFundSocketIds_Request()
        {

        }

        public GetMutualFundSocketIds_Request(string[] fundids)
        {
            this.funds = fundids;
        }
    }

    public class GetMutualFundSocketIds_Response : NasfaqResponse
    {
        public Dictionary<string, string> socketIds { get; set; }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<GetMutualFundSocketIds_Response> GetMutualFundSocketIds(GetMutualFundSocketIds_Request data)
        {
            return await HttpHelper.POST<GetMutualFundSocketIds_Response>(
                httpClient,
                "https://nasfaq.biz/api/getMutualFundSocketIds",
                headers,
                JsonSerializer.Serialize<GetMutualFundSocketIds_Request>(data)
            );
        }

        public async Task<GetMutualFundSocketIds_Response> GetMutualFundSocketIds(string[] fundids)
        {
            return await GetMutualFundSocketIds(new GetMutualFundSocketIds_Request(fundids));
        }

        public async Task<GetMutualFundSocketIds_Response> GetMutualFundSocketIds(string fundid)
        {
            return await GetMutualFundSocketIds(new GetMutualFundSocketIds_Request(new string[] {fundid}));
        }
    }
}