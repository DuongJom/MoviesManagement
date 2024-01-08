using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MoviesManagement.Models
{
    public class User : BaseModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public required string Id { get; set; }
        public required string Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public List<string> AccountIds { get; set; } = null!;
        public List<Account> AccountList { get; set; } = null!;

        [BsonRepresentation(BsonType.ObjectId)]
        public List<string> AddressIds { get; set; } = null!;
        public List<Address> AddressList { get; set; } = null!;
    }
}
