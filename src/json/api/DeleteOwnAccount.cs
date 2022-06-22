using System.Threading.Tasks;
using System.Text.Json;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/deleteOwnAccount
    public class DeleteOwnAccount
    {
        public DeleteOwnAccount(){}
        public DeleteOwnAccount(string password)
        {
            this.password = password;
        }

        public string password { get; set; }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<NasfaqResponse> DeleteOwnAccount(DeleteOwnAccount data)
        {
            return await HttpHelper.POST<NasfaqResponse>(
                httpClient,
                "https://nasfaq.biz/api/deleteOwnAccount",
                headers,
                JsonSerializer.Serialize<DeleteOwnAccount>(data)
            );
        }

        public async Task<NasfaqResponse> DeleteOwnAccount(string password)
        {
            return await DeleteOwnAccount(new DeleteOwnAccount(password));
        }
    }
}