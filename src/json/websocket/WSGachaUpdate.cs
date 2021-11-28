namespace Nasfaq.JSON
{
    //gachaUpdate
    public class WSGachaUpdate : IWebsocketData
    {
        public string[] drops { get; set; }
        public int cashDrops { get; set; }
    }
}