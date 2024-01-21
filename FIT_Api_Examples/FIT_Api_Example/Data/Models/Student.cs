using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Example.Data.Models;

[Table("Student")]// ako obrisemo -onda se koristi TPH
public class Student : KorisnickiNalog
{
    public string BrojIndeksa { get; set; }
    public bool Obrisan { get; set; }


    [ForeignKey(nameof(OpstinaRodjenja))]
    public int OpstinaRodjenjaID { get; set; }
    public Opstina OpstinaRodjenja { get; set; }
}