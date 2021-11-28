namespace Nasfaq.JSON
{
    //api/buySuperchat
    public class BuySuperchat
    {
        public BuySuperchat()
        {
            
        }
        
        public BuySuperchat(double amount, string coin, string message)
        {
            this.amount = amount;
            this.coin = coin;
            this.message = message;
        }

        public double amount { get; set; }
        public string coin { get; set; }
        public string message { get; set; }
    }
}