using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/mutualFundLeaveFund
    public class MutualFundLeaveFund
    {
        public string fund { get; set; }

        public MutualFundLeaveFund()
        {

        }

        public MutualFundLeaveFund(string fund)
        {
            this.fund = fund;
        }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<NasfaqResponse> MutualFundLeaveFund(MutualFundLeaveFund data)
        {
            return await HttpHelper.POST<NasfaqResponse>(
                httpClient,
                "https://nasfaq.biz/api/mutualFundLeaveFund",
                headers,
                JsonSerializer.Serialize<MutualFundLeaveFund>(data)
            );
        }

        public async Task<NasfaqResponse> MutualFundLeaveFund(string fund)
        {
            return await MutualFundLeaveFund(new MutualFundLeaveFund(fund));
        }
    }
}