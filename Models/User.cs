
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using worknet_api.Helpers;

namespace worknet_api.Models
{
    public class User
    {
        public int Id { get; set; } 
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Role { get; set; }
        public string Salts { get; set; } 
        public bool IsLoggedIn { get; set; } = false;
        public string? About { get; set; }
        public byte[]? Image { get; set; }
        public string? PhoneNumber { get; set; }
        [ForeignKey(nameof(Location))]
        public int KorisnikLocationId { get; set; }
        public Location? Location { get; set; }
        //cv

    }
}
