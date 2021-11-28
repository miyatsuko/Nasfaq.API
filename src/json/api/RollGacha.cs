namespace Nasfaq.JSON
{
    //api/rollGacha
    public class RollGacha
    {
        public RollGacha()
        {
            
        }
        
        public RollGacha(bool bulk)
        {
            this.bulk = bulk;
        }

        public bool bulk { get; set; }
    }
}