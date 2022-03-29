namespace Nasfaq.JSON
{
    //api/addChatBlock
    public class AddChatBlock
    {
        public AddChatBlock()
        {

        }

        public AddChatBlock(string blocked)
        {
            this.blocked = blocked;
        }

        public string blocked { get; set; }
    }
}