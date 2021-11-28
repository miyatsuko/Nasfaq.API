using System.Collections.Generic;

namespace Nasfaq.JSON
{
    //api/getUserWallet?userid=id
    public class GetUserWallet
    {
        public bool success { get; set; }
        public UserWallet wallet { get; set; }
    }
    public class UserWallet
    {
        public double balance { get; set; }
        public Dictionary<string, UserWallet_Coin> coins { get; set; }
        public double predicted { get; set; }
    }

    public class UserWallet_Coin
    {
        public int amt { get; set; }
        public long timestamp { get; set; }
        public double meanPurchasePrice { get; set; }
    }
}