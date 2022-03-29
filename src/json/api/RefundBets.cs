namespace Nasfaq.JSON
{
    //api/refundBets
    public class RefundBets
    {
        public RefundBets()
        {

        }

        public RefundBets(string poolid)
        {
            this.poolid = poolid;
        }

        public string poolid { get; set; }
    }
}