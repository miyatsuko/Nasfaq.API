using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/mutualFundTrade
    public class MutualFundTrade
    {
        public string fund { get; set; }
        public Trade_Coin[] orders { get; set; }

        public MutualFundTrade()
        {

        }

        public MutualFundTrade(string fund, string coin, TradeType type)
        {
            this.fund = fund;
            this.orders = new Trade_Coin[] { new Trade_Coin(coin, 1, type) };
        }

        public MutualFundTrade(string fund, string coin, int quantity, TradeType type)
        {
            this.fund = fund;
            this.orders = new Trade_Coin[] { new Trade_Coin(coin, quantity, type) };
        }

        public MutualFundTrade(string fund, string[] buys, string[] sells)
        {
            this.fund = fund;
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

        public MutualFundTrade(string fund, (string, int)[] buys, (string, int)[] sells)
        {
            this.fund = fund;
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

        public MutualFundTrade(string fund, Trade_Coin[] orders)
        {
            this.fund = fund;
            this.orders = orders;
        }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<NasfaqResponse> MutualFundTrade(MutualFundTrade data)
        {
            return await HttpHelper.POST<NasfaqResponse>(
                httpClient,
                "https://nasfaq.biz/api/mutualFundTrade",
                headers,
                JsonSerializer.Serialize<MutualFundTrade>(data)
            );
        }

        public async Task<NasfaqResponse> MutualFundTrade(string fund, string coin, TradeType type)
        {
            return await MutualFundTrade(new MutualFundTrade(fund, coin, type));
        }

        public async Task<NasfaqResponse> MutualFundTrade(string fund, string coin, int quantity, TradeType type)
        {
            return await MutualFundTrade(new MutualFundTrade(fund, coin, quantity, type));
        }

        public async Task<NasfaqResponse> MutualFundTrade(string fund, string[] buys, string[] sells)
        {
            return await MutualFundTrade(new MutualFundTrade(fund, buys, sells));
        }

        public async Task<NasfaqResponse> MutualFundTrade(string fund, (string, int)[] buys, (string, int)[] sells)
        {
            return await MutualFundTrade(new MutualFundTrade(fund, buys, sells));
        }

        public async Task<NasfaqResponse> MutualFundTrade(string fund, Trade_Coin[] orders)
        {
            return await MutualFundTrade(new MutualFundTrade(fund, orders));
        }
    }
}