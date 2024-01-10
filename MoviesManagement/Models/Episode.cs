using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MoviesManagement.Models
{
    public class Episode : BaseModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public Guid Id { get; set; } = Guid.NewGuid();
        public required int EpisodeNo { get; set; }
        public required string Title { get; set; }
        public required Time StartTime { get; set; }
        public required Time EndTime { get; set; }
    }
}
