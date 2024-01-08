using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MoviesManagement.Models
{
    public class Director : User
    {
        public required int NumberOfYearsExperience { get; set; }
        public required List<string> SpecializeIds { get; set; }
        public List<Specialize> SpecializeList { get; set; } = null!;
    }
}
