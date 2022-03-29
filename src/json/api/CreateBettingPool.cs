namespace Nasfaq.JSON
{
    //api/createBettingPool
    public class CreateBettingPool
    {
        public CreateBettingPool()
        {

        }

        public CreateBettingPool(string topic, string[] options, long closingTime)
        {
            this.topic = topic;
            this.options = options;
            this.closingTime = closingTime;
        }

        public string topic { get; set; }
        public string[] options { get; set; }
        public long closingTime { get; set; }
    }
}