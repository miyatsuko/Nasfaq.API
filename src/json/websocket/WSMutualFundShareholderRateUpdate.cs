
namespace Nasfaq.JSON
{
    public class WSMutualFundShareholderRateUpdate : IWebsocketData
    {
        public string fund { get; set; }
        public double rate { get; set; }
    }
}