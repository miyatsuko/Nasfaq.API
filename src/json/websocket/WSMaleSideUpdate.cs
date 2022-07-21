namespace Nasfaq.JSON
{
    //maleSideUpdate
    public class WSMaleSideUpdate : IWebsocketData
    {
        public string[] usersWithMales { get; set; }
        public string[] activeUsers { get; set; }
    }
}