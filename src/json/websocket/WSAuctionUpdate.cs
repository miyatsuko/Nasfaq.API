namespace Nasfaq.JSON
{
    //auctionUpdate
    public class WSAuctionUpdate : IWebsocketData
    {
        //newAuction, newBid, removeAuction, completeAuction
        public string type { get; set; }
        public PlaceAuction_Auction auction { get; set; }
    }
}