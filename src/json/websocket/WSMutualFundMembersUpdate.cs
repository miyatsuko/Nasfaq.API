namespace Nasfaq.JSON
{
    public class WSMutualFundMembersUpdate : IWebsocketData
    {
        //add, remove, makeBoardMember, removeBoardMember
        public string type { get; set; }
        public string fund { get; set; }
        public string username { get; set; }
        public string userid { get; set; }
    }
}