namespace MoviesManagement.Exceptions.Accounts
{
    public class AccountNotFoundException : Exception
    {
        public AccountNotFoundException(string message) { 
            throw new Exception(message);
        }
    }
}
