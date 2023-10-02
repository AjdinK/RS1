using System.ComponentModel.DataAnnotations;

namespace FIT_Api_Example.Modul2.Models
{
    public class Drzava
    {
        [Key]
        public int Id { get; set; }
        public string nazivDrzave { get; set; }
        public string? skracenicaDrzave { get; set; }

    }
}
