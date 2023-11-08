using System.ComponentModel.DataAnnotations;

namespace FIT_Api_Examples.Modul2.Models
{
    public class Drzava
    {
        [Key]
        public int Id { get; set; }
        public string Naziv { get; set; } = string.Empty;
        public string? Skracenica { get; set; } = string.Empty;

    }
}
