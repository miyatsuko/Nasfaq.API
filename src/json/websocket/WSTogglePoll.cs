namespace Nasfaq.JSON
{
    public class WSTogglePoll : IWebsocketData
    {
        public string pollid { get; set; }
        public bool open { get; set; }
    }
}