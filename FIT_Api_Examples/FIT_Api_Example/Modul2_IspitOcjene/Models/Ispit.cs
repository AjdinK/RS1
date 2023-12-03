using System.ComponentModel.DataAnnotations.Schema;
using FIT_Api_Example.Modul1.Models;

namespace FIT_Api_Example.Modul2_IspitOcjene.Models
{
    public class Ispit
    {
        public int ID { get; set; }
        public string Komentar { get; set; }
        public DateTime DatumVrijemeIspita { get; set; }

      
        public int PredmetID { get; set; }
        [ForeignKey(nameof(PredmetID))]
        public Predmet Predmet { get; set; }
    }
}
