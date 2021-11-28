using System.Collections.Generic;

namespace Nasfaq.JSON
{
    //api/getUserItems?userid={id}
    public class GetUserItems
    {
        public bool success { get; set; }
        public Dictionary<string, UserInfo_Item[]> items { get; set; }
    }
}