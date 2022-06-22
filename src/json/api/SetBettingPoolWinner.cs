using System.Threading.Tasks;
using System.Text.Json;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    public class SetBettingPoolWinner
    {
        public SetBettingPoolWinner()
        {

        }

        public SetBettingPoolWinner(string poolid, int winOption)
        {
            this.poolid = poolid;
            this.winOption = winOption;
        }

        public string poolid { get; set; }
        public int winOption { get; set; }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<NasfaqResponse> SetBettingPoolWinner(SetBettingPoolWinner message)
        {
            return await HttpHelper.POST<NasfaqResponse>(
                httpClient,
                "https://nasfaq.biz/api/setBettingPoolWinner",
                headers,
                JsonSerializer.Serialize<SetBettingPoolWinner>(message)
            );
        }

        public async Task<NasfaqResponse> SetBettingPoolWinner(string poolid, int winOption)
        {
            return await SetBettingPoolWinner(new SetBettingPoolWinner(poolid, winOption));
        }
    }
}