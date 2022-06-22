using System.Threading.Tasks;
using System.Text.Json;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/addChatReport
    public class AddChatReport
    {
        public AddChatReport()
        {

        }

        public AddChatReport(string messageid)
        {
            this.messageid = messageid;
        }

        public string messageid { get; set; }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<NasfaqResponse> AddChatReport(AddChatReport data)
        {
            return await HttpHelper.POST<NasfaqResponse>(
                httpClient,
                "https://nasfaq.biz/api/addChatReport",
                headers,
                JsonSerializer.Serialize<AddChatReport>(data)
            );
        }

        public async Task<NasfaqResponse> AddChatReport(string messageid)
        {
            return await AddChatReport(new AddChatReport(messageid));
        }
    }
}