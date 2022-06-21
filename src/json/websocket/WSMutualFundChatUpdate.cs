using System.Collections.Generic;

namespace Nasfaq.JSON
{
    public class WSMutualFundChatUpdate : IWebsocketData
    {
        public string fund { get; set; }
        public string message { get; set; }
    }
}