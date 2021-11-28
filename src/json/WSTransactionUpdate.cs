namespace Nasfaq.JSON
{
    //transactionUpdate
    public class WSTransactionUpdate : IWebsocketData
    {
        public string @event { get; set; }
        public Transaction[] transactions { get; set; }
        public UserWallet wallet { get; set; }
    }
}