namespace Nasfaq.JSON
{
    //api/addMessage
    public class AddMessage
    {
        public AddMessage()
        {
            
        }
        
        public AddMessage(string room, string text)
        {
            this.room = room;
            this.text = text;
        }

        public string room { get; set; }
        public string text { get; set; }
    }
}