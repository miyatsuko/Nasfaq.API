using System.Collections.Generic;

namespace Nasfaq.JSON
{
    //api/getDividends
    public class GetDividends
    {
        public bool success { get; set; }
        public Dividends dividends { get; set; }

    }
    public class Dividends
    {
        public long timestamp { get; set; }
        public Dictionary<string, double> payouts { get; set; }
    }
}