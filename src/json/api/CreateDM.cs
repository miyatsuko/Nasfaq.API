using System.Threading.Tasks;
using System.Text.Json;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/createDM
    public class CreateDM
    {
        public CreateDM()
        {

        }

        public CreateDM(string message, string receiver_username)
        {
            this.message = message;
            this.receiver_username = receiver_username;
        }

        public string message { get; set; }
        public string receiver_username { get; set; }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<NasfaqResponse> CreateDM(CreateDM data)
        {
            return await HttpHelper.POST<NasfaqResponse>(
                httpClient,
                "https://nasfaq.biz/api/createDM",
                headers,
                JsonSerializer.Serialize<CreateDM>(data)
            );
        }

        public async Task<NasfaqResponse> CreateDM(string message, string receiver_username)
        {
            return await CreateDM(new CreateDM(message, receiver_username));
        }
    }
}