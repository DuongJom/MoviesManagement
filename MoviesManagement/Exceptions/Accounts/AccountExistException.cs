namespace MoviesManagement.Exceptions.Accounts
{
    public class AccountExistException : Exception
    {
        public AccountExistException(string message) : base(message) { }
    }
}
