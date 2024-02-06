using BookMyShowNewWebAPI.Database;
using BookMyShowNewWebAPI.Entity;

namespace BookMyShowNewWebAPI.Services
{
    public class WalletService : IWalletService
    {
        private readonly MyContext _context;

        public WalletService(MyContext context)
        {
            _context = context;
        }

        public void CreateWallet(Wallet wallet)
        {
            try
            {
                _context.Wallets.Add(wallet);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteWallet(long WalletID)
        {
            Wallet wallet = _context.Wallets.Find(WalletID);
            if (wallet != null) 
            {
                try
                {
                    _context.Wallets.Remove(wallet);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public void EditWallet(Wallet wallet)
        {
            try
            {
                _context.Wallets.Update(wallet);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            } 
        }

        public List<Wallet> GetAllWallets()
        {
            try
            {
                return _context.Wallets.ToList();
            }
            catch (Exception)
            {

                throw;
            }

        }
        public List<Wallet> GetWalletsByUserID(string userID)
        {
            try
            {
                return _context.Wallets.Where(w => w.UserID == userID).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
