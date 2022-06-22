using System.Threading.Tasks;
using System.Text.Json;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/craftItem
    public class CraftItem
    {
        public CraftItem(){}
        public CraftItem(string[] items)
        {
            this.items = items;
        }

        public string[] items { get; set; }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<NasfaqResponse> CraftItem(string[] items)
        {
            return await HttpHelper.POST<NasfaqResponse>(
                httpClient,
                "https://nasfaq.biz/api/craftItem",
                headers,
                JsonSerializer.Serialize<CraftItem>(new CraftItem() { items = items})
            );
        }
    }
}