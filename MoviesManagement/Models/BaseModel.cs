namespace MoviesManagement.Models
{
    public class BaseModel
    {
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public User? CreateBy { get; set; } = Utils.CurrentUser;
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
        public User? ModifiedBy { get; set; }
    }
}
