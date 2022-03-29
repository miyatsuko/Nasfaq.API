namespace Nasfaq.JSON
{
    //api/rollGacha
    public class RollGacha
    {
        public RollGacha()
        {
            
        }
        
        public RollGacha(int bulk)
        {
            this.bulk = bulk;
        }

        // 0 -> 1 roll, $1000
        // 1 -> 10 rolls, $10000
        // 2 -> 100 rolls, $100000
        public int bulk { get; set; }
    }
}