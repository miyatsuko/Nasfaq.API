namespace Nasfaq.JSON
{
    public class SetBettingPoolWinner
    {
        public SetBettingPoolWinner()
        {

        }

        public SetBettingPoolWinner(string poolid, int winOption)
        {
            this.poolid = poolid;
            this.winOption = winOption;
        }

        public string poolid { get; set; }
        public int winOption { get; set; }
    }
}