using System.Threading.Tasks;
using System.Collections.Generic;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/getDividends
    public class GetDividends
    {
        public bool success { get; set; }
        public Dividends dividends { get; set; }

    }
    public class Dividends
    {
        public long timestamp { get; set; }
        public Dictionary<string, double> payouts { get; set; }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<GetDividends> GetDividends()
        {
            return await HttpHelper.GET<GetDividends>(
                httpClient,
                "https://nasfaq.biz/api/getDividends",
                headers
            );
        }
    }
}