namespace Nasfaq.JSON
{
    //historyUpdate
    public class WSHistoryUpdate : IWebsocketData
    {
        public Transaction[] transactions { get; set; }
    }
}