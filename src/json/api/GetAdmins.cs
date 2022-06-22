using System.Threading.Tasks;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/getAdmins
    public class GetAdmins
    {
        public string[] admins { get; set; }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<GetAdmins> GetAdmins()
        {
            return await HttpHelper.GET<GetAdmins>(
                httpClient,
                "https://nasfaq.biz/api/getAdmins",
                headers
            );
        }
    }
}