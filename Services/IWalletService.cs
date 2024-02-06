using BookMyShowNewWebAPI.Entity;

namespace BookMyShowNewWebAPI.Services
{
    public interface IWalletService
    {
        void CreateWallet(Wallet wallet);
        List<Wallet> GetAllWallets();
        void EditWallet(Wallet wallet);
        void DeleteWallet(long WalletID);
        List<Wallet> GetWalletsByUserID(string userID);
    }
}
