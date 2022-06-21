using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/mutualFundRequestJoin
    public class MutualFundRequestJoin
    {
        public string fund { get; set; }

        public MutualFundRequestJoin()
        {

        }

        public MutualFundRequestJoin(string fund)
        {
            this.fund = fund;
        }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<NasfaqResponse> MutualFundRequestJoin(MutualFundRequestJoin data)
        {
            return await HttpHelper.POST<NasfaqResponse>(
                httpClient,
                "https://nasfaq.biz/api/mutualFundRequestJoin",
                headers,
                JsonSerializer.Serialize<MutualFundRequestJoin>(data)
            );
        }

        public async Task<NasfaqResponse> MutualFundRequestJoin(string fund)
        {
            return await MutualFundRequestJoin(new MutualFundRequestJoin(fund));
        }
    }
}