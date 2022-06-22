using System.Threading.Tasks;
using System.Text.Json;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/setBettingPoolOpenStatus/
    public class SetBettingPoolOptionStatus
    {
        public SetBettingPoolOptionStatus()
        {

        }

        public SetBettingPoolOptionStatus(string poolid, bool openStatus)
        {
            this.poolid = poolid;
            this.openStatus = openStatus;
        }
        public string poolid { get; set; }
        public bool openStatus { get; set; }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<NasfaqResponse> SetBettingPoolOptionStatus(SetBettingPoolOptionStatus message)
        {
            return await HttpHelper.POST<NasfaqResponse>(
                httpClient,
                "https://nasfaq.biz/api/setBettingPoolOpenStatus",
                headers,
                JsonSerializer.Serialize<SetBettingPoolOptionStatus>(message)
            );
        }

        public async Task<NasfaqResponse> SetBettingPoolOptionStatus(string poolid, bool openStatus)
        {
            return await SetBettingPoolOptionStatus(new SetBettingPoolOptionStatus(poolid, openStatus));
        }
    }
}