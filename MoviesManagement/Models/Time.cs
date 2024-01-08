using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MoviesManagement.Models
{
    public class Time : BaseModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public required string Id { get; set; }
        public required int Hours { get; set; }
        public required int Minutes { get; set; }
        public required int Seconds { get; set; }
    }
}
