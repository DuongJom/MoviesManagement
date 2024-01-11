using MoviesManagement.Models;

namespace MoviesManagement.Services.Accounts
{
    public interface IAccountService
    {
        Task<List<Account>> GetAllAccounts();
        Task<Account> GetAccountById(string? id);
        Task<List<Account>> Filter(string filter);
        bool UpdateAccount(string? accountId, Account updateAccount);
        bool DeleteAccount(string? accountId);
        void Login(Account account);
        void SignUp(Account account);
    }
}
