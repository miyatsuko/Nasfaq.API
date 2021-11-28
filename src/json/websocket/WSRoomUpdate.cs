namespace Nasfaq.JSON
{
    //roomUpdate
    public class WSRoomUpdate : IWebsocketData
    {
        public WSRoomUpdate_Update[] roomUpdate { get; set; }
    }

    public class WSRoomUpdate_Update
    {
        public int id { get; set; }
        public long timestamp { get; set; }
        public string username { get; set; }
        public string text { get; set; }
        public int[] mentions { get; set; }
    }
}