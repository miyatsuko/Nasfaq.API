using System.Threading.Tasks;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/getCatalogue
    public class GetItemCatalogue
    {
        public bool success { get; set; }
        public ItemCatalogue_Item[] catalogue { get; set; }
    }

    public class ItemCatalogue_Item
    {
        public string name { get; set; }
        public string description { get; set; }
        public string modifier { get; set; }
        public double modifierMult { get; set; }
        public bool tradeable { get; set; }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<GetItemCatalogue> GetItemCatalogue()
        {
            return await HttpHelper.GET<GetItemCatalogue>(
                httpClient,
                "https://nasfaq.biz/api/getCatalogue",
                headers
            );
        }
    }
}