namespace MoviesManagement.Models
{
    public class Account : BaseModel
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
    }
}
