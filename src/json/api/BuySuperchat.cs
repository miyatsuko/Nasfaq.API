using System.Threading.Tasks;
using System.Text.Json;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/buySuperchat
    public class BuySuperchat
    {
        public BuySuperchat()
        {
            
        }
        
        public BuySuperchat(double amount, string coin, string message)
        {
            this.amount = amount;
            this.coin = coin;
            this.message = message;
        }

        public double amount { get; set; }
        public string coin { get; set; }
        public string message { get; set; }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<string> BuySuperchat(BuySuperchat data)
        {
            return await HttpHelper.POST(
                httpClient,
                "https://nasfaq.biz/api/buySuperchat",
                headers,
                JsonSerializer.Serialize<BuySuperchat>(data)
            );
        }

        public async Task<string> BuySuperchat(double amount, string coin, string message)
        {
            return await BuySuperchat(new BuySuperchat(amount, coin, message));
        }
    }
}