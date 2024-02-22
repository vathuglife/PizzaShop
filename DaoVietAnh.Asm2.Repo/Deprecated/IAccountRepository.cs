using DaoVietAnh.Asm2.Repo.Entities;

namespace DaoVietAnh.Asm2.Repo.Deprecated
{
    public interface IAccountRepository : IDisposable
    {
        IEnumerable<Account> GetAccounts();
        Account GetAccountByID(int accountId);
        void InsertAccount(Account account);
        void DeleteAccount(int accountID);
        void UpdateAccount(Account Account);
        void Save();
    }
}
