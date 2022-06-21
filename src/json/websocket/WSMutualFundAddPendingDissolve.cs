namespace Nasfaq.JSON
{
    public class WSMutualFundAddPendingDissolve : IWebsocketData
    {
        public string fund { get; set; }
        public long timestamp { get; set; }
    }
}