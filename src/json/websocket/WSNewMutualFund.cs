namespace Nasfaq.JSON
{
    public class WSNewMutualFund : IWebsocketData
    {
        public MutualFundData_Fund mutualFundInfo { get; set; }
        public MutualFundData_Stat mutualFundStats { get; set; }
        public MutualFundData_History[] mutualFundHistory { get; set; }
    }
}