using System.Collections.Generic;

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