namespace Nasfaq.JSON
{
    //api/deleteAuctionAdmin
    public class DeleteAuctionAdmin
    {
        public DeleteAuctionAdmin(){}
        public DeleteAuctionAdmin(string auctionid)
        {
            this.auctionid = auctionid;
        }

        public string auctionid { get; set; }
    }
}