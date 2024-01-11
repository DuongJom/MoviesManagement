namespace MoviesManagement.Models
{
    public class Episode : BaseModel
    {
        public required int EpisodeNo { get; set; }
        public required string Title { get; set; }
        public required Time StartTime { get; set; }
        public required Time EndTime { get; set; }
    }
}
