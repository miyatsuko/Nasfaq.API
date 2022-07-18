namespace Nasfaq.JSON
{
    public class WSUpdatePollVotes : IWebsocketData
    {
        public string pollid { get; set; }
        public int old { get; set; }
        public int @new { get; set; }
    }
}