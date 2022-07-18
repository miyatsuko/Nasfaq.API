using System.Threading.Tasks;
using System.Text.Json;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/togglePoll
    public class TogglePoll
    {
        public TogglePoll()
        {

        }

        public TogglePoll(string pollid, bool open)
        {
            this.pollid = pollid;
            this.open = open;
        }

        public string pollid { get; set; }
        public bool open { get; set; }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<NasfaqResponse> TogglePoll(TogglePoll data)
        {
            return await HttpHelper.POST<NasfaqResponse>(
                httpClient,
                "https://nasfaq.biz/api/togglePoll",
                headers,
                JsonSerializer.Serialize<TogglePoll>(data)
            );
        }

        public async Task<NasfaqResponse> TogglePoll(string pollid, bool open)
        {
            return await TogglePoll(new TogglePoll(pollid, open));
        }
    }
}