namespace Nasfaq.JSON
{
    //userWorthUpdate
    public class WSUserWorthUpdate : IWebsocketData
    {
        public long timestamp { get; set; }
        public double networth { get; set; }
    }
}