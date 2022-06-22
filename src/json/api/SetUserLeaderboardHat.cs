using System.Threading.Tasks;
using System.Text.Json;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/setUserLeaderboardHat
    public class SetUserLeaderboardHat
    {
        public SetUserLeaderboardHat(){}
        public SetUserLeaderboardHat(string hat)
        {
            this.hat = hat;
        }

        public string hat { get; set; }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<string> SetUserLeaderboardHat(SetUserLeaderboardHat data)
        {
            return await HttpHelper.POST(
                httpClient,
                "https://nasfaq.biz/api/setUserLeaderboardHat",
                headers,
                JsonSerializer.Serialize<SetUserLeaderboardHat>(data)
            );
        }

        public async Task<string> SetUserLeaderboardHat(string hat)
        {
            return await SetUserLeaderboardHat(new SetUserLeaderboardHat(hat));
        }
    }
}