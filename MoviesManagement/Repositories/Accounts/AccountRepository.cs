using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MoviesManagement.Models;

namespace MoviesManagement.Repositories.Accounts
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IMongoCollection<Account> _accounts;
        private readonly IMongoCollection<User> _users;

        public AccountRepository(IOptions<DBSetting> settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.Value.DatabaseName);
            _accounts = database.GetCollection<Account>("accounts");
            _users = database.GetCollection<User>("users");
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

        public bool CheckAuthentication(Account account)
        {
            var acc = _accounts.Find(x => x.UserName == account.UserName && x.Password == account.Password);
            if (acc == null)
            {
                return false;
            }
            return true;
        }

        public bool CreateAccount(Account account)
        {
            try
            {
                var acc = _accounts.Find(x => x.UserName == account.UserName && x.Password == account.Password).FirstOrDefault();
                if (acc != null)
                {
                    return false;
                }

                _accounts.InsertOneAsync(account);
            }
            catch (Exception)
            {
                return false;
            }
            
            return true;
        }

        public bool UpdateAccount(long? accountId, Account updateAccount)
        {
            try
            {
                if (accountId == null)
                {
                    return false;
                }

                _accounts.FindOneAndReplaceAsync(x => x.Id == accountId, updateAccount);
            }
            catch (Exception)
            {
                return false;
            }
            
            return true;
        }

        public void ResetPassword(long? accountId, string? newPassword)
        {
            var account = GetAccountById(accountId);
            if(account != null)
            {
                account.Password = newPassword;
                _accounts.FindOneAndReplaceAsync(x => x.Id == accountId, account);
            }
        }

        public Account? GetAccountByEmail(string? email)
        {
            //Get all users from database
            var users = _users.Find(x => true).ToList();
            foreach (var user in users)
            {
                if (user.Email == email)
                {
                    return _accounts.Find(x => x.Id == user.AccountId).FirstOrDefault();
                }
            }
            return null;
        }
    }
}
