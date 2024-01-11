using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MoviesManagement.Models
{
    public class User : BaseModel
    {
        public required string Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public List<string> AccountIds { get; set; } = null!;

        [BsonIgnore]
        public List<Account> AccountList { get; set; } = null!;

        [BsonRepresentation(BsonType.ObjectId)]
        public List<string> AddressIds { get; set; } = null!;

        [BsonIgnore]
        public List<Address> AddressList { get; set; } = null!;
    }
}
