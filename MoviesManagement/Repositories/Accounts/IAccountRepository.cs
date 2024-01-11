using MoviesManagement.Models;

namespace MoviesManagement.Repositories.Accounts
{
    public interface IAccountRepository
    {
        Task<List<Account>> GetAllAccounts();
        Task<Account> GetAccountById(string? id);
        Task<List<Account>> Filter(string filter);
        bool UpdateAccount(string? accountId, Account updateAccount);
        bool DeleteAccount(string? accountId);
        void CheckAuthentication(Account account);
        void CreateAccount(Account account);
    }
}
