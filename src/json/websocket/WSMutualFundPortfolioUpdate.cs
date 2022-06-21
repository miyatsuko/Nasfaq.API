using System.Collections.Generic;

namespace Nasfaq.JSON
{
    public class WSMutualFundPortfolioUpdate : IWebsocketData
    {
        public string fund { get; set; }
        public MutualFundPortfolioUpdate_Update tUpdate { get; set; }
    }

    public class MutualFundPortfolioUpdate_Update
    {
        //"Transaction Update"
        public string @event { get; set; }
        public Transaction[] transactions { get; set; }
        public Dictionary<string, MutualFundData_Fund_Portfolio> portfolio { get; set; }
        
    }
}