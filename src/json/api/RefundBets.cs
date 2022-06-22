using System.Threading.Tasks;
using System.Text.Json;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/refundBets
    public class RefundBets
    {
        public RefundBets()
        {

        }

        public RefundBets(string poolid)
        {
            this.poolid = poolid;
        }

        public string poolid { get; set; }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<NasfaqResponse> RefundBets(RefundBets data)
        {
            return await HttpHelper.POST<NasfaqResponse>(
                httpClient,
                "https://nasfaq.biz/api/refundBets",
                headers,
                JsonSerializer.Serialize<RefundBets>(data)
            );
        }

        public async Task<NasfaqResponse> RefundBets(string poolid)
        {
            return await RefundBets(new RefundBets(poolid));
        }
    }
}