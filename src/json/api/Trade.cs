using System.Threading.Tasks;
using System.Text.Json;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/trade
    public class Trade
    {
        public Trade()
        {
            
        }

        public Trade(string coin, TradeType type)
        {
            this.orders = new Trade_Coin[] { new Trade_Coin(coin, 1, type) };
        }

        public Trade(string coin, int quantity, TradeType type)
        {
            this.orders = new Trade_Coin[] { new Trade_Coin(coin, quantity, type) };
        }

        public Trade(string[] buys, string[] sells)
        {
            this.orders = new Trade_Coin[buys.Length + sells.Length];
            int j = 0;
            //important to put sells before buys in the trades
            for(int i = 0; i < sells.Length; i++)
            {
                orders[j] = new Trade_Coin(sells[i], 1, TradeType.Sell);
                j++;
            }
            for(int i = 0; i < buys.Length; i++)
            {
                orders[j] = new Trade_Coin(buys[i], 1, TradeType.Buy);
                j++;
            }
        }

        public Trade((string, int)[] buys, (string, int)[] sells)
        {
            this.orders = new Trade_Coin[buys.Length + sells.Length];
            int j = 0;
            //important to put sells before buys in the trades
            for(int i = 0; i < sells.Length; i++)
            {
                (string, int) item = sells[i];
                orders[j] = new Trade_Coin(item.Item1, item.Item2, TradeType.Sell);
                j++;
            }
            for(int i = 0; i < buys.Length; i++)
            {
                (string, int) item = buys[i];
                orders[j] = new Trade_Coin(item.Item1, item.Item2, TradeType.Buy);
                j++;
            }
        }

        public Trade(Trade_Coin[] orders)
        {
            this.orders = orders;
        }

        public Trade_Coin[] orders { get; set; }
    }

    public class Trade_Coin
    {
        public Trade_Coin(string coin, int quantity, TradeType type)
        {
            this.coin = coin;
            this.quantity = quantity;
            this.type = type;
        }

        public string coin { get; set; }
        public int quantity { get; set; }
        public TradeType type { get; set; }
    }

    public enum TradeType
    {
        Buy = 0,
        Sell = 1
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<NasfaqResponse> Trade(Trade data)
        {
            return await HttpHelper.POST<NasfaqResponse>(
                httpClient,
                "https://nasfaq.biz/api/trade",
                headers,
                JsonSerializer.Serialize<Trade>(data)
            );
        }

        public async Task<NasfaqResponse> Trade(string coin, TradeType type)
        {
            return await Trade(new Trade(coin, type));
        }

        public async Task<NasfaqResponse> Trade(string coin, int quantity, TradeType type)
        {
            return await Trade(new Trade(coin, quantity, type));
        }

        public async Task<NasfaqResponse> Trade(string[] buys, string[] sells)
        {
            return await Trade(new Trade(buys, sells));
        }

        public async Task<NasfaqResponse> Trade((string, int)[] buys, (string, int)[] sells)
        {
            return await Trade(new Trade(buys, sells));
        }

        public async Task<NasfaqResponse> Trade(Trade_Coin[] orders)
        {
            return await Trade(new Trade(orders));
        }
    }
}