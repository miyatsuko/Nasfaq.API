using System.Threading.Tasks;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/getNews
    public class GetNews
    {
        public bool success { get; set; }
        public News[] news { get; set; } 
    }

    public class News
    {
        public string date { get; set; }
        public string[] messages { get; set; }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<GetNews> GetNews()
        {
            return await HttpHelper.GET<GetNews>(
                httpClient,
                "https://nasfaq.biz/api/getNews",
                headers
            );
        }
    }
}