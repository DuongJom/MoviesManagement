namespace MoviesManagement.Models
{
    public class Time : BaseModel
    {
        public required int Hours { get; set; }
        public required int Minutes { get; set; }
        public required int Seconds { get; set; }
    }
}
