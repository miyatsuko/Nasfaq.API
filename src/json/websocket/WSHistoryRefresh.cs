namespace Nasfaq.JSON
{
    //historyRefresh
    public class WSHistoryRefresh : IWebsocketData
    {
        public long timestamp { get; set; }
        public Transaction[] transactions { get; set; }
    }
}