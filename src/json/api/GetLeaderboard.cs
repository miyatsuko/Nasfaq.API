using System.Threading.Tasks;
using System.Collections.Generic;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/getLeaderboard
    public class GetLeaderboard
    {
        public bool success { get; set; } = true;
        //only if success is false
        public string message { get; set; }
        //?leaderboard
        public Leaderboard leaderboard { get; set; }
        //?oshiboard
        public Oshiboard oshiboard { get; set; }
    }

    public class Leaderboard
    {
        public long timestamp {get; set;}
        public Leaderboard_User[] leaderboard { get; set; }
    }

    public class Leaderboard_User
    {
        public string userid { get; set; }
        public string username { get; set; }
        public string icon { get; set; }
        public double networth { get; set; }
        public bool walletIsPublic { get; set; }
        public bool hasItems { get; set; }
        public string color { get; set; }
        public string hat { get; set; }
        public string[] valentines { get; set; }
        public bool inCouple { get; set; }
        public bool active { get; set; }
        public bool ownsMales { get; set; }
    }

    public class Oshiboard
    {
        public long timestamp { get; set; }
        public Dictionary<string, Oshiboard_Board> coins { get; set; }
    }
    public class Oshiboard_Board
    {
        public int totalOwned { get; set; }
        public Oshiboard_Director[] directors { get; set; }
    }

    public class Oshiboard_Director
    {
        public string username { get; set; }
        public string icon { get; set; }
        public int amtOwned { get; set; }
        public string color { get; set; }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<GetLeaderboard> GetLeaderboard(bool leaderboard, bool oshiboard)
        {
            string param = "";
            if(leaderboard) param = "?leaderboard";
            if(oshiboard)
            {
                if(leaderboard) param += "&oshiboard";
                else param = "?oshiboard";
            }
            return await HttpHelper.GET<GetLeaderboard>(
                httpClient,
                $"https://nasfaq.biz/api/getLeaderboard{param}",
                headers
            );
        }
    }
}