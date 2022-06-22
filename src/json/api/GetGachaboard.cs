using System.Threading.Tasks;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/getGachaboard
    public class GetGachaboard
    {
        public Gachaboard_Player[] gachaboard { get; set; }
    }

    public class Gachaboard_Player
    {
        public string username { get; set; }
        public double spentAmt { get; set; }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<GetGachaboard> GetGachaboard()
        {
            return await HttpHelper.GET<GetGachaboard>(
                httpClient,
                "https://nasfaq.biz/api/getGachaboard",
                headers
            );
        }
    }
}