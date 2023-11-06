using System.ComponentModel.DataAnnotations.Schema;
using FIT_Api_Examples.Modul3_MaticnaKnjiga.Models;

namespace FIT_Api_Examples.Modul5_OnlineTestovi.Models
{
    public class StudentTest
    {
        public int Id { get; set; }
        public DateTime TestPokrenutVrijeme { get; set; }
        public DateTime? TestZavrsenoVrijeme { get; set; }
        public float? Uspjeh { get; set; }


        [ForeignKey(nameof(StudentId))]
        public virtual Student Student { get; set; } = null!;
        public int StudentId { get; set; }
        

        [ForeignKey(nameof(AktivacijaTestaId))]
        public virtual AktivacijaTesta AktivacijaTesta { get; set; } = null!;
        public int AktivacijaTestaId { get; set; }

    }
}