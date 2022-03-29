namespace Nasfaq.JSON
{
    //api/removeChatBlock
    public class RemoveChatBlock
    {
        public RemoveChatBlock()
        {

        }

        public RemoveChatBlock(string blocked)
        {
            this.blocked = blocked;
        }

        public string blocked { get; set; }
    }
}