
namespace Nasfaq.JSON
{
    public class WSMutualFundCeoRateUpdate : IWebsocketData
    {
        public string fund { get; set; }
        public double rate { get; set; }
    }
}