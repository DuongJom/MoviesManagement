﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MoviesManagement.Models
{
    public class Time : BaseModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public Guid Id { get; set; } = Guid.NewGuid();
        public required int Hours { get; set; }
        public required int Minutes { get; set; }
        public required int Seconds { get; set; }
    }
}
