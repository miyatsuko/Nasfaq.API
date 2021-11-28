namespace Nasfaq.JSON
{
    //api/getGachaboard
    public class GetGachaboard
    {
        public Gachaboard_Player[] gachaboard { get; set; }
    }

    public class Gachaboard_Player
    {
        public string username { get; set; }
        public double spentAmt { get; set; }
    }
}