using System.Threading.Tasks;
using System.Collections.Generic;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/getUserItems?userid={id}
    public class GetUserItems
    {
        public bool success { get; set; }
        public Dictionary<string, UserInfo_Item[]> items { get; set; }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<GetUserItems> GetUserItems(string userid)
        {
            return await HttpHelper.GET<GetUserItems>(
                httpClient,
                $"https://nasfaq.biz/api/getUserItems?userid={userid}",
                headers
            );
        }
    }
}