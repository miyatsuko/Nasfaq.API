namespace Nasfaq.JSON
{
    //api/addChatDM
    public class AddChatDM
    {
        public AddChatDM()
        {

        }

        public AddChatDM(string message, string receiver)
        {
            this.message = message;
            this.receiver = receiver;
        }

        public string message { get; set; }
        public string receiver { get; set; }
    }
}