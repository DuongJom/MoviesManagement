using MoviesManagement.Models;

namespace MoviesManagement.Services.Accounts
{
    public interface IAccountService
    {
        List<Account> GetAllAccounts();
        Account GetAccountById(long? id);
        List<Account> Filter(string filter);
        bool UpdateAccount(long? accountId, Account updateAccount);
        bool DeleteAccount(long? accountId);
        void Login(Account account);
        void SignUp(Account account);
    }
}
