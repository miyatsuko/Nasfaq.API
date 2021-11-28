namespace Nasfaq.JSON
{
    //coinPriceUpdate
    public class WSCoinPriceUpdate : IWebsocketData
    {
        public string coin { get; set; }
        public WSCoinPriceUpdate_Info info { get; set; }
    }

    public class WSCoinPriceUpdate_Info
    {
        public double price { get; set; }
        public double saleValue { get; set; }
        public int inCirculation { get; set; }
    }
}