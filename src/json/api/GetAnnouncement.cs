namespace Nasfaq.JSON
{
    //api/getAnnouncement
    public class GetAnnouncement
    {
        public bool success { get; set; }
        public Announcement announcement { get; set; }
    }

    public class Announcement
    {
        public string message { get; set; }
        public string date { get; set; }
    }
}