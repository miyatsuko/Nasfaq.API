using System.Threading.Tasks;
using System.Text.Json;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/findEgg
    public class FindEgg
    {
        //Location - eggid
        //----------------------------
        //Icon dialog - c5b38
        //Market - f5f59
        //Benchmark Leaderboard - 10018
        //Stats - 016b7
        //Superchat - 13d8d
        //Gacha - 196ad
        //Auction - 1eb71
        //BenchmarkInfo - 16927
        //Betting - bf836
        //Info - 1bdfa
        public string eggid { get; set; }

        public FindEgg()
        {

        }

        public FindEgg(string eggid)
        {
            this.eggid = eggid;
        }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<NasfaqResponse> FindEgg(FindEgg egg)
        {
            return await HttpHelper.POST<NasfaqResponse>(
                httpClient,
                "https://nasfaq.biz/api/findEgg",
                headers,
                JsonSerializer.Serialize(egg)
            );
        }

        public async Task<NasfaqResponse> FindEgg(string eggid)
        {
            return await HttpHelper.POST<NasfaqResponse>(
                httpClient,
                "https://nasfaq.biz/api/findEgg",
                headers,
                JsonSerializer.Serialize(new FindEgg(eggid))
            );
        }
    }
}