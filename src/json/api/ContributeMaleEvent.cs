using System.Threading.Tasks;
using System.Text.Json;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{   
    //api/contributeMaleEvent
    public class ContributeMaleEvent
    {
        public ContributeMaleEvent()
        {

        }

        //1, 10, 50
        public ContributeMaleEvent(int percent)
        {
            this.percent = percent;
        }

        public int percent { get; set; }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<NasfaqResponse> ContributeMaleEvent(ContributeMaleEvent data)
        {
            return await HttpHelper.POST<NasfaqResponse>(
                httpClient,
                "https://nasfaq.biz/api/contributeMaleEvent",
                headers,
                JsonSerializer.Serialize<ContributeMaleEvent>(data)
            );
        }

        public async Task<NasfaqResponse> ContributeMaleEvent(int percent)
        {
            return await ContributeMaleEvent(new ContributeMaleEvent(percent));
        }
    }
}