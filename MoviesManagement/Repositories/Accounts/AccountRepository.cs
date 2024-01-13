using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MoviesManagement.Exceptions.Accounts;
using MoviesManagement.Models;

namespace MoviesManagement.Repositories.Accounts
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IMongoCollection<Account> _accounts;

        public AccountRepository(IOptions<DBSetting> settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.Value.DatabaseName);
            _accounts = database.GetCollection<Account>("accounts");
        }
        public bool DeleteAccount(long? accountId)
        {
            try
            {
                if (accountId == null)
                {
                    return false;
                }

                _accounts.DeleteOneAsync(x => x.Id == accountId);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public List<Account> Filter(string filterValue)
        {
            var filter = Builders<Account>.Filter.Eq("UserName", filterValue);
            return _accounts.Find(filter).ToList();
        }

        public Account GetAccountById(long? id)
        {
            return _accounts.Find(x => x.Id == id).FirstOrDefault();
        }

        public List<Account> GetAllAccounts()
        {
            return _accounts.Find(x => true).ToList();
        }

        public void CheckAuthentication(Account account)
        {
            var acc = _accounts.Find(x => x.UserName == account.UserName && x.Password == account.Password);
            if (acc == null)
            {
                throw new InvalidAccountException("Invalid account!");
            }
        }

        public void CreateAccount(Account account)
        {
            var acc = _accounts.Find(x => x.UserName == account.UserName && x.Password == account.Password).FirstOrDefault();
            if (acc != null)
            {
                throw new AccountExistException($"Account with username={account.UserName} already exist!");
            }

            _accounts.InsertOneAsync(account);
        }

        public bool UpdateAccount(long? accountId, Account updateAccount)
        {
            if (accountId == null)
            {
                return false;
            }

            _accounts.FindOneAndReplaceAsync(x => x.Id == accountId, updateAccount);
            return true;
        }
    }
}
