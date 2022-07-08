using System.Threading.Tasks;
using System.Collections.Generic;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/getMarketInfo
    public class GetMarketInfo : NasfaqResponse
    {
        //?all
        //?coins={coin1},{coin2},{coin...}
        public MarketInfo_Coins coinInfo { get; set; }
        public bool marketSwitch { get; set; }
        //needs &brokerFeeTotal
        public double brokerFeeTotal { get; set; }
        //needs &brokerFee
        public double brokerFee { get; set; }
    }

    public class MarketInfo_Coins
    {
        public Dictionary<string, MarketInfo_CoinInfo> data { get; set; }
        public long timestamp { get; set; }
    }

    public class MarketInfo_CoinInfo
    {
        public string coin { get; set; }
        public double price { get; set; }
        public double saleValue { get; set; }
        public int inCirculation { get; set; }
        //needs &history
        public MarketInfo_CoinHistoryTick[] history { get; set; }
    }

    public class MarketInfo_CoinHistoryTick
    {
        public long timestamp { get; set; }
        public double price { get; set; }
        public int inCirculation { get; set; }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<GetMarketInfo> GetMarketInfo(bool showPrice, bool showSaleValue, bool showInCirculation, bool showHistory, bool showBrokerFeeTotal, bool showBrokerFee)
        {
            return await GetMarketInfo("?all", showPrice, showSaleValue, showInCirculation, showHistory, showBrokerFeeTotal, showBrokerFee);
        }

        public async Task<GetMarketInfo> GetMarketInfo(IList<string> coins, bool showPrice, bool showSaleValue, bool showInCirculation, bool showHistory, bool showBrokerFeeTotal, bool showBrokerFee)
        {
            string coinsstr = "?coins=";
            for(int i = 0; i < coins.Count; i++)
            {
                coinsstr += coins[i];
                if(i + 1 < coins.Count - 1)
                {
                    coinsstr += ",";
                }
            }
            return await GetMarketInfo(coinsstr, showPrice, showSaleValue, showInCirculation, showHistory, showBrokerFeeTotal, showBrokerFee);
        }

        private async Task<GetMarketInfo> GetMarketInfo(string coins, bool showPrice, bool showSaleValue, bool showInCirculation, bool showHistory, bool showBrokerFeeTotal, bool showBrokerFee)
        {
            return await HttpHelper.GET<GetMarketInfo>(
                httpClient,
                $"https://nasfaq.biz/api/getMarketInfo{coins}&price={showPrice.ToString().ToLower()}&saleValue={showSaleValue.ToString().ToLower()}&inCirculation={showInCirculation.ToString().ToLower()}{(showHistory ? "&history" : "")}{(showBrokerFeeTotal ? "&brokerFeeTotal" : "")}{(showBrokerFee ? "&brokerFee" : "")}",
                headers
            );
        }
    }
}