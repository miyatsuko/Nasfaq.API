using System.Threading.Tasks;
using System.Text.Json;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/addChatDM
    public class AddChatDM
    {
        public AddChatDM()
        {

        }

        public AddChatDM(string message, string receiver)
        {
            this.message = message;
            this.receiver = receiver;
        }

        public string message { get; set; }
        public string receiver { get; set; }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<NasfaqResponse> AddChatDM(AddChatDM data)
        {
            return await HttpHelper.POST<NasfaqResponse>(
                httpClient,
                "https://nasfaq.biz/api/addChatDM",
                headers,
                JsonSerializer.Serialize<AddChatDM>(data)
            );
        }

        public async Task<NasfaqResponse> AddChatDM(string message, string receiver_id)
        {
            return await AddChatDM(new AddChatDM(message, receiver_id));
        }
    }
}