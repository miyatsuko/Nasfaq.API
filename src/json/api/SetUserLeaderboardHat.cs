namespace Nasfaq.JSON
{
    //api/setUserLeaderboardHat
    public class SetUserLeaderboardHat
    {
        public SetUserLeaderboardHat(){}
        public SetUserLeaderboardHat(string hat)
        {
            this.hat = hat;
        }

        public string hat { get; set; }
    }
}