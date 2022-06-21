using System.Collections.Generic;

namespace Nasfaq.JSON
{
    public class WSMutualFundDailyHistoryUpdate : Dictionary<string, MutualFundData_History>, IWebsocketData
    {
    }
}