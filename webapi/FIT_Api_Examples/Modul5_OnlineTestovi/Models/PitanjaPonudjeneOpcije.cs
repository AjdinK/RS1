using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Examples.Modul5_OnlineTestovi.Models
{
    public class PitanjaPonudjeneOpcije
    {
        public int Id { get; set; }
        public string Opis { get; set; } = string.Empty;
        public bool JelTacno { get; set; }

        [ForeignKey(nameof(PitanjaId))]
        public int PitanjaId { get; set; }
        public Pitanje Pitanje { get; set; } = null!;
    }
}