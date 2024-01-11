using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MoviesManagement.Models
{
    public class Movie : BaseModel
    {
        public required string MovieName { get; set; }
        public required string Url { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public required List<string> DirectorIds { get; set; }
        
        [BsonIgnore]
        public List<Director> DirectorList { get; set; } = null!;

        [BsonRepresentation(BsonType.ObjectId)]
        public required List<string> EpisodeIds { get; set; }

        [BsonIgnore]
        public List<Episode> Episodes { get; set; } = null!;
    }
}
