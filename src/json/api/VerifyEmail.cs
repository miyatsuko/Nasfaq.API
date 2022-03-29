namespace Nasfaq.JSON
{
    //api/verifyEmail
    public class VerifyEmail
    {
        public VerifyEmail(){}
        public VerifyEmail(string userid, string key)
        {
            this.userid = userid;
            this.key = key;
        }

        public string userid { get; set; }
        public string key { get; set; }
    }
}