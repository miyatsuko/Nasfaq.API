
namespace Nasfaq.JSON
{
    //api/craftItem
    public class CraftItem
    {
        public CraftItem(){}
        public CraftItem(string[] items)
        {
            this.items = items;
        }

        public string[] items { get; set; }
    }
}