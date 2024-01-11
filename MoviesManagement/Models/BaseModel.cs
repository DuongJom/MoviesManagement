using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MoviesManagement.Models
{
    public class BaseModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public User? CreateBy { get; set; } = Utils.CurrentUser;
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
        public User? ModifiedBy { get; set; }
    }
}
