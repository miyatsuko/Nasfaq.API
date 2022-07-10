
namespace Nasfaq.JSON
{
    public class WSMutualFundAutotraderUpdate : IWebsocketData
    {
        public string fund { get; set; }
        public MutualFundAutotraderUpdate_Autotrader autotrader { get; set; }
    }

    public class MutualFundAutotraderUpdate_Autotrader
    {
        public bool? running { get; set; }
        public UpdateFundAutoTraderRules_Rule[] rules { get; set; }
    }
}