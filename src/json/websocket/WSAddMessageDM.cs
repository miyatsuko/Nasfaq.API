namespace Nasfaq.JSON
{
    //addMessageDM
    public class WSAddMessageDM : IWebsocketData
    {
        public string roomid { get; set; }
        public AddMessageDM_DM message { get; set; }
    }
    
    public class AddMessageDM_DM : IWebsocketData
    {
        public string userid { get; set; }
        public string username { get; set; }
        public int messageid { get; set; }
        public string message { get; set; }
        public long timestamp { get; set; }
    }
}