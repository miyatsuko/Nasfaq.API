namespace Nasfaq.JSON
{
    //api/addRoom
    public class AddRoom
    {
        public AddRoom()
        {
            
        }
        
        public AddRoom(string subject, string openingText)
        {
            this.subject = subject;
            this.openingText = openingText;
        }

        public string subject { get; set; }
        public string openingText { get; set; }
    }
}