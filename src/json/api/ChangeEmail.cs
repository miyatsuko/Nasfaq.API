using System.Threading.Tasks;
using System.Text.Json;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/changeEmail
    public class ChangeEmail
    {
        public ChangeEmail()
        {
            
        }
        
        public ChangeEmail(string email)
        {
            this.email = email;
        }

        public string email { get; set; }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<string> ChangeEmail(ChangeEmail data)
        {
            return await HttpHelper.POST(
                httpClient,
                "https://nasfaq.biz/api/changeEmail",
                headers,
                JsonSerializer.Serialize<ChangeEmail>(data)
            );
        }

        public async Task<string> ChangeEmail(string email)
        {
            return await ChangeEmail(new ChangeEmail(email));
        }
    }
}