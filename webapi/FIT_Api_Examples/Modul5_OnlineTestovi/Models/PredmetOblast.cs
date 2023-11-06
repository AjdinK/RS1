using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FIT_Api_Examples.Modul2.Models;

namespace FIT_Api_Examples.Modul5_OnlineTestovi.Models
{
    public class PredmetOblast
    {
        [Key]
        public int Id { get; set; }
        public string Naziv { get; set; } = string.Empty;


        [ForeignKey(nameof(PredmetId))]
        public int PredmetId { get; set; }
        public Predmet Predmet { get; set; } = null!;

    }
}