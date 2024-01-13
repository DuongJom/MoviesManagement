using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MoviesManagement.Models
{
    public class BaseModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.Int64)]
        public long Id { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public User? CreateBy { get; set; } = Utils.CurrentUser;
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
        public User? ModifiedBy { get; set; }
    }
}
