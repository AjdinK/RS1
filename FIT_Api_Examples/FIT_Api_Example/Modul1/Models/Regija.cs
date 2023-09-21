using FIT_Api_Example.Modul2.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Example.Modul1.Models
{
    public class Regija
    {
        [Key]
        public int Id { get; set; }
        public string description { get; set; }

        [ForeignKey (nameof(DrzavaID))]
        public Drzava Drzava { get; set; }
        public int DrzavaID { get; set; }

    }
}
