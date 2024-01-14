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
        bool Login(Account account);
        bool SignUp(Account account);
        void ResetPassword(long? accountId, string? newPassword);
        Account? GetAccountByEmail(string? email);
    }
}
