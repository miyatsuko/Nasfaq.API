using System.Threading.Tasks;
using System.Text.Json;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/deletePoll
    public class DeletePoll
    {
        public DeletePoll()
        {

        }

        public DeletePoll(string pollid)
        {
            this.pollid = pollid;
        }

        public string pollid { get; set; }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<NasfaqResponse> DeletePoll(DeletePoll data)
        {
            return await HttpHelper.POST<NasfaqResponse>(
                httpClient,
                "https://nasfaq.biz/api/deletePoll",
                headers,
                JsonSerializer.Serialize<DeletePoll>(data)
            );
        }

        public async Task<NasfaqResponse> DeletePoll(string pollid)
        {
            return await DeletePoll(new DeletePoll(pollid));
        }
    }
}