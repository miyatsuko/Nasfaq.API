using System.Threading.Tasks;
using System.Text.Json;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/verifyEmail
    public class VerifyEmail
    {
        public VerifyEmail(){}
        public VerifyEmail(string userid, string key)
        {
            this.userid = userid;
            this.key = key;
        }

        public string userid { get; set; }
        public string key { get; set; }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<NasfaqResponse> VerifyEmail(VerifyEmail data)
        {
            return await HttpHelper.POST<NasfaqResponse>(
                httpClient,
                "https://nasfaq.biz/api/verifyEmail",
                headers,
                JsonSerializer.Serialize<VerifyEmail>(data)
            );
        }

        public async Task<NasfaqResponse> VerifyEmail(string userid, string key)
        {
            return await VerifyEmail(new VerifyEmail(userid, key));
        }
    }
}