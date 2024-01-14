using MoviesManagement.Models;
using MoviesManagement.Repositories.Accounts;

namespace MoviesManagement.Services.Accounts
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public bool DeleteAccount(long? accountId)
        {
            return _accountRepository.DeleteAccount(accountId);
        }

        public List<Account> Filter(string filter)
        {
            return _accountRepository.Filter(filter);
        }

        public Account? GetAccountByEmail(string? email)
        {
            return _accountRepository.GetAccountByEmail(email);
        }

        public Account GetAccountById(long? id)
        {
            return _accountRepository.GetAccountById(id);
        }

        public List<Account> GetAllAccounts()
        {
            return _accountRepository.GetAllAccounts();
        }

        public bool Login(Account account)
        {
            return _accountRepository.CheckAuthentication(account);
        }

        public void ResetPassword(long? accountId, string? newPassword)
        {
            _accountRepository.ResetPassword(accountId, newPassword);
        }

        public bool SignUp(Account account)
        {
            return _accountRepository.CreateAccount(account);
        }

        public bool UpdateAccount(long? accountId, Account updateAccount)
        {
            return _accountRepository.UpdateAccount(accountId, updateAccount);
        }
    }
}
