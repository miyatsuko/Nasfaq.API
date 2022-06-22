using System.Threading.Tasks;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/getGlobalChat
    public class GetGlobalChat
    {
        public GlobalChat_Message[] chat { get; set; }
    }

    public class GlobalChat_Message
    {
        public bool IsAnonymous()
        {
            return !int.TryParse(userid, out _);
        }

        public string userid { get; set; }
        public string username { get; set ; }
        public int messageid { get; set; }
        public string message { get; set; }
        public long timestamp { get; set; }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<GetGlobalChat> GetGlobalChat()
        {
            return await HttpHelper.GET<GetGlobalChat>(
                httpClient,
                "https://nasfaq.biz/api/getGlobalChat",
                headers
            );
        }
    }
}