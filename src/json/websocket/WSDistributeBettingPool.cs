namespace Nasfaq.JSON
{
    //distributeBettingPool
    public class WSDistributeBettingPool : IWebsocketData
    {
        public string poolid { get; set; }
        public int winOptions { get; set; }
    }
}