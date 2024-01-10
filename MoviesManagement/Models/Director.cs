using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MoviesManagement.Models
{
    public class Director : User
    {
        public required int NumberOfYearsExperience { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public required List<string> SpecializeIds { get; set; }

        [BsonIgnore]
        public List<Specialize> SpecializeList { get; set; } = null!;
    }
}
