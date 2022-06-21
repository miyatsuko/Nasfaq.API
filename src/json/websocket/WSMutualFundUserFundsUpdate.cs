using System.Collections.Generic;

namespace Nasfaq.JSON
{
    public class WSMutualFundUserFundsUpdate : IWebsocketData
    {
        public Dictionary<string, UserInfo_UserMutualFunds> userFunds { get; set; } 
    }
}