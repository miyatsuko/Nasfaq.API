namespace Nasfaq.JSON
{
    //addChatBlock
    public class WSAddChatBlock : IWebsocketData
    {
        public string blocker { get; set; }
        public string blocked { get; set; }
    }
}