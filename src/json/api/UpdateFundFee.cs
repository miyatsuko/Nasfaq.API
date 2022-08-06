using System.Threading.Tasks;
using System.Text.Json;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/updateFundFee
    public class UpdateFundFee
    {
        public double fee { get; set; }
        public string fund { get; set; }

        public UpdateFundFee()
        {

        }

        public UpdateFundFee(string fund, double fee)
        {
            this.fund = fund;
            this.fee = fee;
        }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<NasfaqResponse> UpdateFundFee(UpdateFundFee data)
        {
            return await HttpHelper.POST<NasfaqResponse>(
                httpClient,
                "https://nasfaq.biz/api/updateFundFee",
                headers,
                JsonSerializer.Serialize<UpdateFundFee>(data)
            );
        }

        public async Task<NasfaqResponse> UpdateFundFee(string fund, double fee)
        {
            return await UpdateFundFee(new UpdateFundFee(fund, fee));
        }
    }
}