using System.ComponentModel.DataAnnotations.Schema;

namespace worknet_api.Models
{
    public class Token
    {
        public int Id { get; set; }
        public string Value { get; set; }
        [ForeignKey(nameof(Korisnik))]
        public int KorisnikId { get; set; }
        public Korisnik Korisnik { get; set; }
        public DateTime Date { get; set; }
    }

}
