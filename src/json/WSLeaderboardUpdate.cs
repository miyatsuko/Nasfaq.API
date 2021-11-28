namespace Nasfaq.JSON
{
    //leaderboardUpdate
    public class WSLeaderboardUpdate : IWebsocketData
    {
        public Leaderboard leaderboard { get; set; }
        public Oshiboard oshiboard { get; set; }
    }
}