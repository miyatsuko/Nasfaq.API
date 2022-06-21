using System.Collections.Generic;

namespace Nasfaq.JSON
{
    public class WSMutualFundUserOrderUpdate : IWebsocketData
    {
        public string fund { get; set; }
        public int buys { get; set; }
        public int sells { get; set; }
    }
}