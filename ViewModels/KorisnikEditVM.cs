using System.ComponentModel.DataAnnotations.Schema;
using worknet_api.Models;

namespace worknet_api.ViewModels
{
    public class KorisnikEditVM
    {
        public string? About { get; set; }
        public byte[]? Image { get; set; }
        public string? PhoneNumber { get; set; }
        public string? WorkedAt { get; set; }
        public string? University { get; set; }
        public Location Location { get; set; }
        public string? Owner { get; set; }

    }
}
