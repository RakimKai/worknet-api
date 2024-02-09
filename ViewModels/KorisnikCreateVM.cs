using System.Security.Cryptography;

namespace worknet_api.ViewModels
{
    public class KorisnikCreateVM
    {
        public string Email { get; set; }
        public string? Ime { get; set; }
        public string? Prezime { get; set; }
        public string? ImeKompanije { get; set; }
        public string Password { get; set; }
       

    }
}
