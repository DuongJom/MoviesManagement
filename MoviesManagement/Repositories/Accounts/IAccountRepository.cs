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
        bool CheckAuthentication(Account account);
        bool CreateAccount(Account account);
        void ResetPassword(long? accountId, string? newPassword);
        Account? GetAccountByEmail(string? email);
    }
}
