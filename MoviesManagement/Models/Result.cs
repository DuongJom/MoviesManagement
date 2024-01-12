using System.Net;

namespace MoviesManagement.Models
{
    public class Result
    {
        public HttpStatusCode StatusCode { get; set; }
        public string? Message { get; set; }
        public object? Data { get; set; }
    }
}
