using System.ComponentModel.DataAnnotations;

namespace FIT_Api_Example.Modul1.Models
{
    public class Predmet
    {
        [Key]
        public int ID { get; set; }
        public string nazivPredmeta { get; set; }
        public string sifraPredmeta { get; set; }
        public int ectsBodovi { get; set; }
    }
}
