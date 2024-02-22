using DaoVietAnh.Asm2.Repo.Deprecated;
using DaoVietAnh.Asm2.Repo.Entities;
using Microsoft.EntityFrameworkCore;

namespace DaoVietAnh.Asm2.Repo.Deprecated.Implementations
{
    public class AccountRepository : IAccountRepository, IDisposable
    {
        private ShoppingWebsiteDBContext? _dbContext;
        private bool disposed = false;
        public AccountRepository(ShoppingWebsiteDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteAccount(int accountID)
        {
            Account account = _dbContext?.Accounts.Find(accountID)!;
            _dbContext?.Accounts.Remove(account);
        }


        public Account GetAccountByID(int accountId)
        {
            return _dbContext!.Accounts.Find(accountId)!;
        }

        public IEnumerable<Account> GetAccounts()
        {
            return _dbContext!.Accounts.ToList();
        }

        public void InsertAccount(Account account)
        {
            _dbContext?.Accounts.Add(account);
        }

        public void Save()
        {
            _dbContext?.SaveChanges();
        }

        public void UpdateAccount(Account Account)
        {
            _dbContext!.Entry(Account).State = EntityState.Modified;
        }
        public void Dispose()
        {

            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _dbContext?.Dispose();
                }
            }
            disposed = true;
        }
    }
}
