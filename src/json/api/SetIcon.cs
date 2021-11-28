namespace Nasfaq.JSON
{
    //api/setIcon
    public class SetIcon
    {
        public SetIcon()
        {
            
        }
        
        public SetIcon(string icon)
        {
            this.icon = icon;
        }

        public string icon { get; set; }
    }
}