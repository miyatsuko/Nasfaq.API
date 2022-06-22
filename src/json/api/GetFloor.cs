using System.Threading.Tasks;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/getFloor
    public class GetFloor
    {
        public GetFloor_Floor floor { get; set; }
    }

    public class GetFloor_Floor
    {
        public int postCount { get; set; }
        public Floor_Room[] rooms { get; set; }
    }

    public class Floor_Room
    {
        public string id { get; set; }
        public long timestamp { get; set; }
        public string subject { get; set; }
        public string opening { get; set; }
        public string creator { get; set; }
        public int posts { get; set; }
        public string[] posters { get; set; }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<GetFloor> GetFloor()
        {
            return await HttpHelper.GET<GetFloor>(
                httpClient,
                "https://nasfaq.biz/api/getFloor",
                headers
            );
        }
    }
}