using System.Threading.Tasks;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/getSession
    public class GetSession
    {
        public bool loggedout { get; set; }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<GetSession> GetSession()
        {
            return await HttpHelper.GET<GetSession>(
                httpClient,
                "https://nasfaq.biz/api/getSession",
                headers
            );
        }
    }
}