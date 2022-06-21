using System.Collections.Generic;

namespace Nasfaq.JSON
{
    public class WSMutualFundBulletinUpdate : IWebsocketData
    {
        public string fund { get; set; }
        public MutualFundData_Bulletin bulletin { get; set; }
    }
}