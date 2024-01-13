using MoviesManagement.Models;

namespace MoviesManagement.Repositories.Accounts
{
    public interface IAccountRepository
    {
        List<Account> GetAllAccounts();
        Account GetAccountById(long? id);
        List<Account> Filter(string filter);
        bool UpdateAccount(long? accountId, Account updateAccount);
        bool DeleteAccount(long? accountId);
        void CheckAuthentication(Account account);
        void CreateAccount(Account account);
    }
}
