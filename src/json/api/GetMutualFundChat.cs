using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/getMutualFundChat?fund={}
    public class GetMutualFundChat : NasfaqResponse
    {
        public string fund { get; set; }
        public GetMutualFundChat_Log[] chatLog { get; set; }
    }

    public class GetMutualFundChat_Log
    {
        public string user { get; set; }
        public string message { get; set; }
        public long timestamp { get; set; }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<GetMutualFundChat> GetMutualFundChat(string fundid)
        {
            return await HttpHelper.GET<GetMutualFundChat>(
                httpClient,
                $"https://nasfaq.biz/api/getMutualFundChat?fund={fundid}",
                headers
            );
        }
    }
}