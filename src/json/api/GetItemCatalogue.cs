namespace Nasfaq.JSON
{
    //api/getCatalogue
    public class GetItemCatalogue
    {
        public bool success { get; set; }
        public ItemCatalogue_Item[] catalogue { get; set; }
    }

    public class ItemCatalogue_Item
    {
        public string name { get; set; }
        public string description { get; set; }
        public string modifier { get; set; }
        public double modifierMult { get; set; }
    }
}