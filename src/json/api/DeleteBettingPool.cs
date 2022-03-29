namespace Nasfaq.JSON
{
    //api/deleteBettingPool
    public class DeleteBettingPool
    {
        public DeleteBettingPool()
        {

        }

        public DeleteBettingPool(string poolid)
        {
            this.poolid = poolid;
        }

        public string poolid { get; set; }
    }
}