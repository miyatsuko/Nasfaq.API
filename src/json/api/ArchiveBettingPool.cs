namespace Nasfaq.JSON
{
    //api/archiveBettingPool
    public class ArchiveBettingPool
    {
        public ArchiveBettingPool()
        {

        }

        public ArchiveBettingPool(string poolid)
        {
            this.poolid = poolid;
        }

        public string poolid { get; set; }
    }
}