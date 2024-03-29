﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MoviesManagement.Models
{
    public class Address : BaseModel
    {
        public string? StreetNo { get; set; }
        public string? StreetName { get; set; }
        public string? District { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Area { get; set; }
    }
}
