namespace Nasfaq.JSON
{
    //walletUpdate
    public class WSWalletUpdate : IWebsocketData
    {
        public UserWallet wallet { get; set; }
    }
}