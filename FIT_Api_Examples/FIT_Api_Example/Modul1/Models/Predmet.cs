using System.ComponentModel.DataAnnotations;

namespace FIT_Api_Example.Modul1.Models
{
    public class Predmet
    {
        [Key]
        public int ID { get; set; }
        public string Naziv { get; set; }
        public string Skracenica { get; set; }
        public int ECTS { get; set; }
    }
}
