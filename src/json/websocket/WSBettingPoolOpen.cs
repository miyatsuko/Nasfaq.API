namespace Nasfaq.JSON
{
    //bettingPoolOpen
    public class WSBettingPoolOpen : IWebsocketData
    {
        public string poolid { get; set; }
        public bool isOpen { get; set; }
    }
}