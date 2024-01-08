using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MoviesManagement.Models
{
    public class Movie : BaseModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public required string Id { get; set; }
        public required string MovieName { get; set; }
        public required string Url { get; set; }

        public required List<string> DirectorIds { get; set; }
        public List<Director> DirectorList { get; set; } = null!;

        public required List<string> EpisodeIds { get; set; }
        public List<Episode> Episodes { get; set; } = null!;
    }
}
