using System.Threading.Tasks;
using System.Text.Json;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/updateFundCeoDivRate
    public class UpdateFundCeoDivRate
    {
        public double rate { get; set; }
        public string fund { get; set; }

        public UpdateFundCeoDivRate()
        {

        }

        public UpdateFundCeoDivRate(string fund, double fee)
        {
            this.fund = fund;
            this.rate = fee;
        }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<NasfaqResponse> UpdateFundCeoDivRate(UpdateFundCeoDivRate data)
        {
            return await HttpHelper.POST<NasfaqResponse>(
                httpClient,
                "https://nasfaq.biz/api/updateFundCeoDivRate",
                headers,
                JsonSerializer.Serialize<UpdateFundCeoDivRate>(data)
            );
        }

        public async Task<NasfaqResponse> UpdateFundCeoDivRate(string fund, double rate)
        {
            return await UpdateFundCeoDivRate(new UpdateFundCeoDivRate(fund, rate));
        }
    }
}