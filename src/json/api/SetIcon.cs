using System.Threading.Tasks;
using System.Text.Json;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/setIcon
    public class SetIcon
    {
        public SetIcon()
        {
            
        }
        
        public SetIcon(string icon)
        {
            this.icon = icon;
        }

        public string icon { get; set; }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<string> SetIcon(SetIcon data)
        {
            return await HttpHelper.POST(
                httpClient,
                "https://nasfaq.biz/api/setIcon",
                headers,
                JsonSerializer.Serialize<SetIcon>(data)
            );
        }

        public async Task<string> SetIcon(string icon)
        {
            return await SetIcon(new SetIcon(icon));
        }
    }
}