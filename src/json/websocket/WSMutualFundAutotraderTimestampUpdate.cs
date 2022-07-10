
namespace Nasfaq.JSON
{
    public class WSMutualFundAutotraderTimestampUpdate : IWebsocketData
    {
        public string fund { get; set; }
        public long timestamp { get; set; }
    }
}