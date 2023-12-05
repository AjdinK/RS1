using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Example.Data.Models;

public class Ispit
{
    public int ID { get; set; }
    public string Komentar { get; set; }
    public DateTime DatumVrijemeIspita { get; set; }


    public int PredmetID { get; set; }
    [ForeignKey(nameof(PredmetID))]
    public Predmet Predmet { get; set; }
}