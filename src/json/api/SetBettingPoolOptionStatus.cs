namespace Nasfaq.JSON
{
    //api/setBettingPoolOpenStatus/
    public class SetBettingPoolOptionStatus
    {
        public SetBettingPoolOptionStatus()
        {

        }

        public SetBettingPoolOptionStatus(string poolid, bool openStatus)
        {
            this.poolid = poolid;
            this.openStatus = openStatus;
        }
        public string poolid { get; set; }
        public bool openStatus { get; set; }
    }
}