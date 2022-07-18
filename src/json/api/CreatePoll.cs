using System.Threading.Tasks;
using System.Text.Json;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/createPoll
    public class CreatePoll
    {
        public CreatePoll()
        {

        }

        public CreatePoll(string subject, string[] options)
        {
            this.subject = subject;
            this.options = options;
        }

        public string subject { get; set; }
        public string[] options { get; set; }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<NasfaqResponse> CreatePoll(CreatePoll data)
        {
            return await HttpHelper.POST<NasfaqResponse>(
                httpClient,
                "https://nasfaq.biz/api/createPoll",
                headers,
                JsonSerializer.Serialize<CreatePoll>(data)
            );
        }

        public async Task<NasfaqResponse> CreatePoll(string subject, string[] options)
        {
            return await CreatePoll(new CreatePoll(subject, options));
        }
    }
}