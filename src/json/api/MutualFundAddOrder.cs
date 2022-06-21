using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/mutualFundAddOrder
    public class MutualFundAddOrder
    {
        public string fund { get; set; }
        public int quantity { get; set; }

        public MutualFundAddOrder()
        {

        }

        public MutualFundAddOrder(string fund, int quantity)
        {
            this.fund = fund;
            this.quantity = quantity;
        }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<NasfaqResponse> MutualFundAddOrder(MutualFundAddOrder data)
        {
            return await HttpHelper.POST<NasfaqResponse>(
                httpClient,
                "https://nasfaq.biz/api/mutualFundAddOrder",
                headers,
                JsonSerializer.Serialize<MutualFundAddOrder>(data)
            );
        }

        public async Task<NasfaqResponse> MutualFundAddOrder(string fund, int quantity)
        {
            return await MutualFundAddOrder(new MutualFundAddOrder(fund, quantity));
        }
    }
}