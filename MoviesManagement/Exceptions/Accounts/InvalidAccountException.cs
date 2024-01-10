namespace MoviesManagement.Exceptions.Accounts
{
    public class InvalidAccountException : Exception
    {
        public InvalidAccountException(string message) { 
            throw new Exception(message);
        }
    }
}
