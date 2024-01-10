using MoviesManagement.Models;

namespace MoviesManagement.Repositories.Accounts
{
    public interface IAccountRepository
    {
        Task<List<Account>> GetAllAccounts();
        Task<Account> GetAccountById(Guid? id);
        Task<List<Account>> Filter(string filter);
        bool UpdateAccount(Guid? accountId, Account updateAccount);
        bool DeleteAccount(Guid? accountId);
        void CheckAuthentication(Account account);
        void CreateAccount(Account account);
    }
}
