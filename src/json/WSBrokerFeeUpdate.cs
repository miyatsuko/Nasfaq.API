namespace Nasfaq.JSON
{
    //brokerFeeUpdate
    public class WSBrokerFeeUpdate : IWebsocketData
    {
        public string userid { get; set; }
        public double amount { get; set; }
    }
}