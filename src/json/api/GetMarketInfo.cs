using System.Threading.Tasks;
using System.Collections.Generic;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/getMarketInfo
    public class GetMarketInfo
    {
        public bool success { get; set; } = true;
        //only if success is false
        public string message { get; set; }

        //?all
        //?coins={coin1},{coin2},{coin...}
        public MarketInfo_Coins coinInfo { get; set; }
        public bool marketSwitch { get; set; }
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
        public async Task<GetMarketInfo> GetMarketInfo(bool showPrice, bool showSaleValue, bool showInCirculation, bool showHistory)
        {
            return await GetMarketInfo("?all", showPrice, showSaleValue, showInCirculation, showHistory);
        }

        public async Task<GetMarketInfo> GetMarketInfo(IList<string> coins, bool showPrice, bool showSaleValue, bool showInCirculation, bool showHistory)
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
            return await GetMarketInfo(coinsstr, showPrice, showSaleValue, showInCirculation, showHistory);
        }

        private async Task<GetMarketInfo> GetMarketInfo(string coins, bool showPrice, bool showSaleValue, bool showInCirculation, bool showHistory)
        {
            return await HttpHelper.GET<GetMarketInfo>(
                httpClient,
                $"https://nasfaq.biz/api/getMarketInfo{coins}&price={showPrice.ToString().ToLower()}&saleValue={showSaleValue.ToString().ToLower()}&inCirculation={showInCirculation.ToString().ToLower()}{(showHistory ? "&history" : "")}",
                headers
            );
        }
    }
}