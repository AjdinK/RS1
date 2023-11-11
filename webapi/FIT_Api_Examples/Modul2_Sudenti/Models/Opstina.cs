using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Examples.Modul2.Models
{
    public class Opstina
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;

        
        [ForeignKey(nameof(Drzava))]
        public int DrzavaId { get; set; }
        public Drzava Drzava { get; set; } = null!;
    }
}
