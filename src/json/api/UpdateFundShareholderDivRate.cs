using System.Threading.Tasks;
using System.Text.Json;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/updateFundShareholderDivRate
    public class UpdateFundShareholderDivRate
    {
        public double rate { get; set; }
        public string fund { get; set; }

        public UpdateFundShareholderDivRate()
        {

        }

        public UpdateFundShareholderDivRate(string fund, double fee)
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
        public async Task<NasfaqResponse> UpdateFundShareholderDivRate(UpdateFundShareholderDivRate data)
        {
            return await HttpHelper.POST<NasfaqResponse>(
                httpClient,
                "https://nasfaq.biz/api/updateFundShareholderDivRate",
                headers,
                JsonSerializer.Serialize<UpdateFundShareholderDivRate>(data)
            );
        }

        public async Task<NasfaqResponse> UpdateFundShareholderDivRate(string fund, double rate)
        {
            return await UpdateFundShareholderDivRate(new UpdateFundShareholderDivRate(fund, rate));
        }
    }
}