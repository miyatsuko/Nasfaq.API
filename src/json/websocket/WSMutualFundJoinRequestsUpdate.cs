namespace Nasfaq.JSON
{
    public class WSMutualFundJoinRequestsUpdate : IWebsocketData
    {
        public string fund { get; set; }
        public string id { get; set; }
        public string username { get; set; }
        public bool remove { get; set; } = false;
    }
}