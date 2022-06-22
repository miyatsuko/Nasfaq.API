using System.Threading.Tasks;
using System.Text.Json;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/setUserLeaderboardColor
    public class SetUserLeaderboardColor
    {
        public SetUserLeaderboardColor()
        {
            
        }

        public SetUserLeaderboardColor(string color)
        {
            this.color = color;
        }

        //"default", "red", "pink", "lime", blue", "purple", "orange", "yellow", "green", "magenta", "gray"
        public string color { get; set; }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<string> SetUserLeaderboardColor(SetUserLeaderboardColor data)
        {
            return await HttpHelper.POST(
                httpClient,
                "https://nasfaq.biz/api/setUserLeaderboardColor",
                headers,
                JsonSerializer.Serialize<SetUserLeaderboardColor>(data)
            );
        }

        public async Task<string> SetUserLeaderboardColor(string color)
        {
            return await SetUserLeaderboardColor(new SetUserLeaderboardColor(color));
        }
    }
}