using System.Collections.Generic;

namespace Nasfaq.JSON
{
    public class WSMutualFundRemoveUserRequest : IWebsocketData
    {
        public string fund { get; set; }
    }
}