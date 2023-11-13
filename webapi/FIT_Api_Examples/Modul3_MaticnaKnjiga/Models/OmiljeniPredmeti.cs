using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FIT_Api_Examples.Modul2.Models;
using FIT_Api_Examples.Modul3_MaticnaKnjiga.Models;

public class OmiljeniPredmeti
{

    [Key]
    public int Id { get; set; }

    [ForeignKey(nameof(StudentId))]
    public int StudentId { get; set; }
    public Student Student { get; set; } = null!;


    [ForeignKey(nameof(PredmetId))]
    public int PredmetId { get; set; }
    public Predmet Predmet { get; set; } = null!;

}