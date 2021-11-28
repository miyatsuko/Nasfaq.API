using System.Collections.Generic;

namespace Nasfaq.JSON
{
    //api/getStats
    public class GetStats
    {   
        public Dictionary<string, Stats> stats { get; set; }
        public Stats_CoinHistory[] coinHistory { get; set; }
    }

    public class GetStats_Raw
    {   
        public Dictionary<string, Stats> stats { get; set; }
        public string coinHistory { get; set; }
    }
    
    public class Stats
    {
        public Stats_Data subscriberCount { get; set; }
        public Stats_Data dailySubscriberCount { get; set; }
        public Stats_Data weeklySubscriberCount { get; set; }
        public Stats_Data viewCount { get; set; }
        public Stats_Data dailyViewCount { get; set; }
        public Stats_Data weeklyViewCount { get; set; }
    }

    public class Stats_Data
    {
        public string name { get; set; }
        public string[] labels { get; set; }
        public int[] data { get; set; }
    }

    public class Stats_CoinHistory
    {
        public long timestamp { get; set; }
        public Dictionary<string, Stats_CoinInfo> data { get; set; }
    }

    public class Stats_CoinInfo
    {
        public string coin { get; set; }
        public double price { get; set; }
        public int inCirculation { get; set; }
    }
}