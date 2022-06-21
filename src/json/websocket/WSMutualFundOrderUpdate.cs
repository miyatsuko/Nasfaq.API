namespace Nasfaq.JSON
{
    public class WSMutualFundOrderUpdate : IWebsocketData
    {
        public string fund { get; set; }
        public int buys { get; set; }
        public int sells { get; set; }
    }
}