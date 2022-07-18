using System.Threading.Tasks;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/getPolls
    public class GetPolls : NasfaqResponse
    {
        public GetPolls_Poll[] polls { get; set; }
    }

    public class GetPolls_Poll
    {
        public string id { get; set; }
        public string subject { get; set; }
        public bool open { get; set; }
        public GetPolls_Option[] options { get; set; }
    }

    public class GetPolls_Option
    {
        public int id { get; set; }
        public string value { get; set; }
        public int votes {get; set; }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<GetPolls> GetPolls()
        {
            return await HttpHelper.GET<GetPolls>(
                httpClient,
                "https://nasfaq.biz/api/getPolls",
                headers
            );
        }
    }
}