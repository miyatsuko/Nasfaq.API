namespace Nasfaq.JSON
{
    //api/placeBet
    public class PlaceBet
    {
        public PlaceBet()
        {

        }

        public PlaceBet(string poolid, double betAmount, int option)
        {
            this.poolid = poolid;
            this.betAmount = betAmount;
            this.option = option;
        }

        public string poolid { get; set; }
        public double betAmount { get; set; }
        public int option { get; set; }
    }
}