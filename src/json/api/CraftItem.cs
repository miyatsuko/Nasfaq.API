
namespace Nasfaq.API
{
    public class CraftItem_Request
    {
        public string[] items { get; set; }
    }

    public class CraftItem_Response
    {
        public bool success { get; set; }
        public string message { get; set; }
    }
}