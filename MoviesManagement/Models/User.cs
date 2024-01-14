using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MoviesManagement.Models
{
    public class User : BaseModel
    {
        public required string Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }

        [BsonRepresentation(BsonType.Int64)]
        public long? AccountId { get; set; }

        [BsonIgnore]
        public Account? Account { get; set; }

        [BsonRepresentation(BsonType.Int64)]
        public List<long> AddressIds { get; set; } = null!;

        [BsonIgnore]
        public List<Address> AddressList { get; set; } = null!;
    }
}
