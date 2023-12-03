using System.ComponentModel.DataAnnotations.Schema;
using FIT_Api_Examples.Modul2.Models;

namespace FIT_Api_Examples.Modul5_OnlineTestovi.Models
{
    public class AktivacijaTesta
    {
        public int Id { get; set; }
        public string Naziv { get; set; } = string.Empty;
        public float TrajanjeMinute { get; set; }
        public DateTime Pocetak { get; set; }
        public DateTime Kraj { get; set; }

        [ForeignKey(nameof(PredmetId))]
        public virtual Predmet Predmet { get; set; } = null!;
        public int PredmetId { get; set; }

    }
}