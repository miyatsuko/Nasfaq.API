
namespace Nasfaq.JSON
{
    //api/sendAuctionMessage
    public class SendAuctionMessage_Request
    {
        public SendAuctionMessage_Request()
        {

        }

        public SendAuctionMessage_Request(string auctionId, string message)
        {
            this.auctionID = auctionId;
            this.message = message;
        }

        public string auctionID { get; set; }
        public string message { get; set; }
    }

    public class SendAuctionMessage_Response
    {
        public bool success { get; set; }
        public string reason { get; set; }
    }
}