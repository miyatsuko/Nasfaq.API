using System.Threading.Tasks;
using System.Text.Json;
using Nasfaq.JSON;

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

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<SendAuctionMessage_Response> SendAuctionMessage(SendAuctionMessage_Request message)
        {
            return await HttpHelper.POST<SendAuctionMessage_Response>(
                httpClient,
                "https://nasfaq.biz/api/sendAuctionMessage",
                headers,
                JsonSerializer.Serialize<SendAuctionMessage_Request>(message)
            );
        }

        public async Task<SendAuctionMessage_Response> SendAuctionMessage(string auctionId, string message)
        {
            return await SendAuctionMessage(new SendAuctionMessage_Request(auctionId, message));
        }
    }
}