namespace MoviesManagement.Exceptions.Accounts
{
    public class AccountExistException : Exception
    {
        public AccountExistException(string message) {
            throw new Exception(message);
        }
    }
}
