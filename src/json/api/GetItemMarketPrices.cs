using System.Threading.Tasks;
using System.Collections.Generic;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/getItemMarketPrices
    public class GetItemMarketPrices
    {
        public bool success { get; set; }
        public Dictionary<string, ItemMarketPrices_Item> catalogue { get; set; }
    }

    public class ItemMarketPrices_Item
    {
        public string item { get; set; }
        public double price { get; set; }
        public int maxAmount { get; set; }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<GetItemMarketPrices> GetItemMarketPrices()
        {
            return await HttpHelper.GET<GetItemMarketPrices>(
                httpClient,
                "https://nasfaq.biz/api/getItemMarketPrices",
                headers
            );
        }
    }
}