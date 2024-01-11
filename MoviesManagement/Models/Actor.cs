namespace MoviesManagement.Models
{
    public class Actor : BaseModel
    {
        public required string Name { get; set; }
        public required bool Gender { get; set; }
    }
}
