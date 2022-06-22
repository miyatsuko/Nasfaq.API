using System.Threading.Tasks;
using System.Text.Json;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/changeUsername
    public class ChangeUsername
    {
        public ChangeUsername()
        {
            
        }
        
        public ChangeUsername(string username)
        {
            this.username = username;
        }

        public string username { get; set; }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<string> ChangeUsername(ChangeUsername data)
        {
            return await HttpHelper.POST(
                httpClient,
                "https://nasfaq.biz/api/changeUsername",
                headers,
                JsonSerializer.Serialize<ChangeUsername>(data)
            );
        }

        public async Task<string> ChangeUsername(string username)
        {
            return await ChangeUsername(new ChangeUsername(username));
        }
    }
}