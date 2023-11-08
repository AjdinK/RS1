using System;
using System.ComponentModel.DataAnnotations.Schema;
using FIT_Api_Examples.Modul0_Autentifikacija.Models;
using FIT_Api_Examples.Modul2.Models;

namespace FIT_Api_Examples.Modul3_MaticnaKnjiga.Models
{
    [Table("Student")]
    public class Student : KorisnickiNalog
    {
        public string Broj_Indeksa { get; set; }
        public DateTime Created_Time { get; set; }

        [ForeignKey(nameof(Opstina_Rodjenja))]
        public int? Opstina_Rodjenja_Id { get; set; }
        public Opstina Opstina_Rodjenja { get; set; }

    }
}
