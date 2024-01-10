using MoviesManagement.Models;

namespace MoviesManagement.Services.Accounts
{
    public interface IAccountService
    {
        Task<List<Account>> GetAllAccounts();
        Task<Account> GetAccountById(Guid id);
        Task<List<Account>> Filter(string filter);
        bool UpdateAccount(Guid accountId, Account updateAccount);
        bool DeleteAccount(Guid accountId);
        void Login(Account account);
        void SignUp(Account account);
    }
}
