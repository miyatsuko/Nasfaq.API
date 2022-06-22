using System.Threading.Tasks;
using System.Text.Json;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/createBettingPool
    public class CreateBettingPool
    {
        public CreateBettingPool()
        {

        }

        public CreateBettingPool(string topic, string[] options, long closingTime)
        {
            this.topic = topic;
            this.options = options;
            this.closingTime = closingTime;
        }

        public string topic { get; set; }
        public string[] options { get; set; }
        public long closingTime { get; set; }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<NasfaqResponse> CreateBettingPool(CreateBettingPool data)
        {
            return await HttpHelper.POST<NasfaqResponse>(
                httpClient,
                "https://nasfaq.biz/api/createBettingPool",
                headers,
                JsonSerializer.Serialize<CreateBettingPool>(data)
            );
        }

        public async Task<NasfaqResponse> CreateBettingPool(string topic, string[] options, long closingTime)
        {
            return await CreateBettingPool(new CreateBettingPool(topic, options, closingTime));
        }
    }
}