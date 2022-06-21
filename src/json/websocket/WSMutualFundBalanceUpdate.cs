using System.Collections.Generic;

namespace Nasfaq.JSON
{
    public class WSMutualFundBalanceUpdate : IWebsocketData
    {
        public Dictionary<string, double> funds { get; set; }
    }
}