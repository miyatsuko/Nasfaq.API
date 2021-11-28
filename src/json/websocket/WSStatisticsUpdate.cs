using System.Collections.Generic;

namespace Nasfaq.JSON
{
    public class WSStatisticsUpdate: IWebsocketData
    {
        public Dictionary<string, Stats> stats { get; set; }
    }
}