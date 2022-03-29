namespace Nasfaq.JSON
{
    //api/deleteOwnAccount
    public class DeleteOwnAccount
    {
        public DeleteOwnAccount(){}
        public DeleteOwnAccount(string password)
        {
            this.password = password;
        }

        public string password { get; set; }
    }
}