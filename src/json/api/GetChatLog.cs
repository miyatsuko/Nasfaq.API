using System.Threading.Tasks;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/getChatLog
    //api/getChatLog?room={roomid}
    public class GetChatLog
    {
        public bool success { get; set; } = true;
        public ChatLog_Entry[] chatLog { get; set; }
    }

    public class ChatLog_Entry
    {
        public int id { get; set; }
        public long timestamp { get; set; }
        public string username { get; set; }
        public string text { get; set; }
        public string[] mentions { get; set; }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<GetChatLog> GetChatLog(string roomid)
        {
            return await HttpHelper.GET<GetChatLog>(
                httpClient,
                $"https://nasfaq.biz/api/getChatLog?room={roomid}",
                headers
            );
        }
    }
}