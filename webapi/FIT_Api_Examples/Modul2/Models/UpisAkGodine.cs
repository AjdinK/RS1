using FIT_Api_Examples.Modul3_MaticnaKnjiga.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Examples.Modul2.Models
{
    public class UpisAkGodine
    {
        [Key]
        public int Id { get; set; }
        public DateTime DatumUpisZimski { get; set; }
        public int GodinaStudija { get; set; }

        public float CijenaSkolarine { get; set; }

        public bool JelObnova { get; set; }

        [ForeignKey (nameof(StudentID))]
        public Student Student { get; set; }
        public int StudentID { get; set; }

        [ForeignKey(nameof(AkademskaGodinaID))]
        public AkademskaGodina AkademskaGodina { get; set; }
        public int AkademskaGodinaID { get; set; }

    }
}
