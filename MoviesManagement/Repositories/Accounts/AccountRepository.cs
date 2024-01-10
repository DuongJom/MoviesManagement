using MongoDB.Driver;
using MoviesManagement.Exceptions.Accounts;
using MoviesManagement.Models;

namespace MoviesManagement.Repositories.Accounts
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IMongoClient _client;
        private readonly IMongoCollection<Account> _accounts;

        public AccountRepository(IMongoDatabase database, IMongoClient mongoClient)
        {
            _client = mongoClient;
            _accounts = database.GetCollection<Account>("accounts");
        }
        public bool DeleteAccount(Guid? accountId)
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

        public async Task<List<Account>> Filter(string filterValue)
        {
            var filter = Builders<Account>.Filter.Eq("UserName", filterValue);
            return await _accounts.Find(filter).ToListAsync();
        }

        public async Task<Account> GetAccountById(Guid? id)
        {
            return await _accounts.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Account>> GetAllAccounts()
        {
            return await _accounts.Find(x => true).ToListAsync();
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
            var acc = _accounts.Find(x => x.UserName == account.UserName && x.Password == account.Password);
            if (acc != null)
            {
                throw new AccountExistException($"Account with username={account.UserName} already exist!");
            }

            _accounts.InsertOneAsync(account);
        }

        public bool UpdateAccount(Guid? accountId, Account updateAccount)
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
