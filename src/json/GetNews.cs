namespace Nasfaq.JSON
{
    //api/getNews
    public class GetNews
    {
        public bool success { get; set; }
        public News[] news { get; set; } 
    }

    public class News
    {
        public string date { get; set; }
        public string[] messages { get; set; }
    }
}