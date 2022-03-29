using System.Collections.Generic;

namespace Nasfaq.JSON
{
    //api/getItemMarketPrices
    public class GetItemMarketPrices
    {
        public bool success { get; set; }
        public Dictionary<string, ItemMarketPrices_Item> catalogue { get; set; }
    }

    public class ItemMarketPrices_Item
    {
        public string item { get; set; }
        public double price { get; set; }
        public int maxAmount { get; set; }
    }
}