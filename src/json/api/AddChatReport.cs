namespace Nasfaq.JSON
{
    //api/addChatReport
    public class AddChatReport
    {
        public AddChatReport()
        {

        }

        public AddChatReport(string messageid)
        {
            this.messageid = messageid;
        }

        public string messageid { get; set; }
    }
}