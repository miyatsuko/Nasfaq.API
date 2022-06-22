using System.Collections.Generic;

namespace Nasfaq.JSON
{
    //mutualFundStatUpdate
    public class WSMutualFundStatUpdate : IWebsocketData
    {
        public Dictionary<string, MutualFundData_Stat> funds { get; set; }
    }
}