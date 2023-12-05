using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Example.Data.Models;

public class PrijavaIspita
{
    public int ID { get; set; }
    public DateTime DatumPrijave { get; set; }

    public DateTime? OdjavaIspit { get; set; }

    public int StudentID { get; set; }
    [ForeignKey(nameof(StudentID))]
    public Student Student { get; set; }


    public int IspitID { get; set; }
    [ForeignKey(nameof(IspitID))]
    public Ispit Ispit { get; set; }
}