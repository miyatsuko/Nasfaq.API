namespace Nasfaq.JSON
{
    //api/addChatGlobal
    public class AddChatGlobal
    {
        public AddChatGlobal()
        {

        }

        public AddChatGlobal(string message, bool anonymous)
        {
            this.message = message;
            this.anonymous = anonymous;
        }

        public bool anonymous { get; set; }
        public string message { get; set; }
    }
}