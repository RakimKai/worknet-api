using System.Text.Json.Serialization;

namespace worknet_api.Models
{
    public class Company : Korisnik
    {
        public string CompanyName { get; set; }
        public string? CompanyOwner {  get; set; }
        [JsonIgnore]
        public List<Post>? Posts { get; set; }
        public List<Review> Reviews { get; set; } = new List<Review>();

    }
}
