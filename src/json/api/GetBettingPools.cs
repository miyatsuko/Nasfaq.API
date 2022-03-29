using System.Collections.Generic;

namespace Nasfaq.JSON
{
    //api/getBettingPools
    public class GetBettingPools
    {
        public bool success { get; set; }
        public Dictionary<string, BettingPools> bettingPools { get; set; }
    }

    public class BettingPools
    {
        public string id { get; set; }
        public string topic { get; set; }
        public bool open { get; set; }
        public int winOption { get; set; }
        public double totalPool { get; set; }
        public long closingTime { get; set; }
        public BettingPools_Option[] options { get; set; }
        public BettingPools_Bet[,] userBets { get; set; }
    }

    public class BettingPools_Option
    {
        public int optionid { get; set; }
        public string option { get; set; }
    }

    public class BettingPools_Bet
    {
        public string userid { get; set; }
        public string username { get; set; }
        public double betAmount { get; set; }
        public int option { get; set; }
    }
}