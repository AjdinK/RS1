using FIT_Api_Example.Modul2.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Example.Modul1.Models
{
    public class Ocjena

    {
        [Key]
        public int ID { get; set; }
        public int ocjena { get; set; }

        [ForeignKey (nameof(PredmetID))]
        public Predmet Predmet { get; set; }
        public int PredmetID { get; set; }

        [ForeignKey(nameof(StudentID))]
        public Student Student { get; set; }
        public int StudentID { get; set; }
        public int? BrojacnaOcjena { get; set; }

    }
}
