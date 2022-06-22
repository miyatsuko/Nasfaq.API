using System.Threading.Tasks;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/getAnnouncement
    public class GetAnnouncement
    {
        public bool success { get; set; }
        public Announcement announcement { get; set; }
    }

    public class Announcement
    {
        public string message { get; set; }
        public string date { get; set; }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<GetAnnouncement> GetAnnouncement()
        {
            return await HttpHelper.GET<GetAnnouncement>(
                httpClient,
                "https://nasfaq.biz/api/getAnnouncement",
                headers
            );
        }
    }
}