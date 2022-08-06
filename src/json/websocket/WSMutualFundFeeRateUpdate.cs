
namespace Nasfaq.JSON
{
    public class WSMutualFundFeeRateUpdate : IWebsocketData
    {
        public string fund { get; set; }
        public double fee { get; set; }
    }
}