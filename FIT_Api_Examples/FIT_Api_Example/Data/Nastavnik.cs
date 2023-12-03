using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Example.Data
{
    [Table("Nastavnik")]
    public class Nastavnik : KorisnickiNalog
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }

    }
}
