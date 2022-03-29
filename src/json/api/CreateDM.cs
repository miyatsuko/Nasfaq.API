namespace Nasfaq.JSON
{
    //api/createDM
    public class CreateDM
    {
        public CreateDM()
        {

        }

        public CreateDM(string message, string receiver_username)
        {
            this.message = message;
            this.receiver_username = receiver_username;
        }

        public string message { get; set; }
        public string receiver_username { get; set; }
    }
}