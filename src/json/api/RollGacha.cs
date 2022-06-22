using System.Threading.Tasks;
using System.Text.Json;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/rollGacha
    public class RollGacha
    {
        public RollGacha()
        {
            
        }
        
        public RollGacha(int bulk)
        {
            this.bulk = bulk;
        }

        // 0 -> 1 roll, $1000
        // 1 -> 10 rolls, $10000
        // 2 -> 100 rolls, $100000
        public int bulk { get; set; }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<string> RollGacha(RollGacha data)
        {
            return await HttpHelper.POST(
                httpClient,
                "https://nasfaq.biz/api/rollGacha",
                headers,
                JsonSerializer.Serialize<RollGacha>(data)
            );
        }

        public async Task<string> RollGacha(int bulk)
        {
            return await RollGacha(new RollGacha(bulk));
        }
    }
}