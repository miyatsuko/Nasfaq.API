using System.Threading.Tasks;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/destroySession
    public class DestroySession
    {
        public bool success { get; set; }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<DestroySession> DestroySession()
        {
            return await HttpHelper.GET<DestroySession>(
                httpClient,
                "https://nasfaq.biz/api/destroySession",
                headers
            );
        }
    }
}