using System.Threading.Tasks;
using System.Text.Json;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/removeChatBlock
    public class RemoveChatBlock
    {
        public RemoveChatBlock()
        {

        }

        public RemoveChatBlock(string blocked)
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
        public async Task<NasfaqResponse> RemoveChatBlock(RemoveChatBlock data)
        {
            return await HttpHelper.POST<NasfaqResponse>(
                httpClient,
                "https://nasfaq.biz/api/removeChatBlock",
                headers,
                JsonSerializer.Serialize<RemoveChatBlock>(data)
            );
        }

        public async Task<NasfaqResponse> RemoveChatBlock(string blocked)
        {
            return await RemoveChatBlock(new RemoveChatBlock(blocked));
        }
    }
}