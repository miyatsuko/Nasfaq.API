using System.Threading.Tasks;
using System.Text.Json;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/addChatBlock
    public class AddChatBlock
    {
        public AddChatBlock()
        {

        }

        public AddChatBlock(string blocked)
        {
            this.blocked = blocked;
        }

        public string blocked { get; set; }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<NasfaqResponse> AddChatBlock(AddChatBlock data)
        {
            return await HttpHelper.POST<NasfaqResponse>(
                httpClient,
                "https://nasfaq.biz/api/addChatBlock",
                headers,
                JsonSerializer.Serialize<AddChatBlock>(data)
            );
        }

        public async Task<NasfaqResponse> AddChatBlock(string blockedPlayer)
        {
            return await AddChatBlock(new AddChatBlock(blockedPlayer));
        }
    }
}