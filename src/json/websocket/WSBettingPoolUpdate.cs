namespace Nasfaq.JSON
{
    //bettingPoolUpdate
    public class WSBettingPoolUpdate : IWebsocketData
    {
        public string poolid { get; set; }
        public WSUserBetUpdate_UserBet userBet { get; set; }
    }

    public class WSBettingPoolUpdate_BettingPool
    {
        public string id { get; set; }
        public string topic { get; set; }
        public bool open { get; set; }
        public int? winOption { get; set; }
        public int totalPool { get; set; }
        public long closingTime { get; set; }
        public BettingPools_Option[] options { get; set; }
        public BettingPools_Bet[,] userBets { get; set; }
    }
}