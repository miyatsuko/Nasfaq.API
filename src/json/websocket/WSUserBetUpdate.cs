namespace Nasfaq.JSON
{
    //userBetUpdate
    public class WSUserBetUpdate : IWebsocketData
    {
        public string poolid { get; set; }
        public WSUserBetUpdate_UserBet userBet { get; set; }
    }

    public class WSUserBetUpdate_UserBet
    {
        public string userid { get; set; }
        public string username { get; set; }
        public double betAmount { get; set; }
        public int option { get; set; }
    }
}