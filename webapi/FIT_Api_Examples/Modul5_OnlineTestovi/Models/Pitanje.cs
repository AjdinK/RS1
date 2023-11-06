
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Examples.Modul5_OnlineTestovi.Models
{
    public enum TipPitanja
    {
        SCMA, MCMA
    }

    public class Pitanje
    {
        public int Id { get; set; }
        public string TekstPitanja { get; set; } = string.Empty;
        public int BodoviPozitivni { get; set; }
        public int BodoviNegativni { get; set; }
        public bool ParciijalnoBodovanja { get; set; }
        public TipPitanja TipPitanja { get; set; }
        public virtual List<PitanjaPonudjeneOpcije> PitanjaPonudjeneOpcijes { get; set; } = null!;


        [ForeignKey(nameof(PredmetOblastId))]
        public virtual PredmetOblast PredmetOblast { get; set; } = null!;
        public int PredmetOblastId { get; set; }
        
    }
}