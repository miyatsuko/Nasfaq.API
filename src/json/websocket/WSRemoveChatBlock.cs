namespace Nasfaq.JSON
{
    //removeChatBlock
    public class WSRemoveChatBlock : IWebsocketData
    {
        public string blocker { get; set; }
        public string blocked { get; set; }
    }
}