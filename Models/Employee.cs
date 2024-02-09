namespace worknet_api.Models
{
    public class Employee : Korisnik
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? WorkedAt { get; set; }
        public string? University { get; set; }
        public List<string>? Skills { get; set; } = new List<string>();
        public List<Review> Reviews { get; set; } = new List<Review>();

    }
}