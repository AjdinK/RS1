using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Example.Modul1.Models
{
    public class Ispit
    {
        [Key]
        public int Id { get; set; }
        public string Naziv { get; set; }
        public DateTime Datum { get; set; }

        [ForeignKey("PredmetID")]
        public Predmet Predmet { get; set; }
        public int PredmetID { get; set; }

    }
}
