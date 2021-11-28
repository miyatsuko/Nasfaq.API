namespace Nasfaq.JSON
{
    //api/changeUsername
    public class ChangeUsername
    {
        public ChangeUsername()
        {
            
        }
        
        public ChangeUsername(string username)
        {
            this.username = username;
        }

        public string username { get; set; }
    }
}