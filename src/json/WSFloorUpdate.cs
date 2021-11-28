namespace Nasfaq.JSON
{
    //floorUpdate
    public class WSFloorUpdate : IWebsocketData
    {
        public int postCount { get; set; }
        public WSFloorUpdate_Room[] rooms { get; set; }
    }

    public class WSFloorUpdate_Room
    {
        public string id { get; set; }
        public long timestamp { get; set; }
        public string subject { get; set; }
        public string opening { get; set; }
        public string creator { get; set; }
        public int posts { get; set; }
        public string[] posters { get; set; }
    }
}