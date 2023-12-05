using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Example.Data.Models;

public class Obavijest
{

    [Key]
    public int ID { get; set; }
    public string Naslov { get; set; }
    public string Tekst { get; set; }
    public DateTime DatumKreiranja { get; set; }



    public int CreatedByKorisnikID { get; set; }
    [ForeignKey(nameof(CreatedByKorisnikID))]
    public KorisnickiNalog EvidentiraoKorisnik { get; set; }


    [ForeignKey(nameof(IzmijenioKorisnik))]
    public int? IzmijenioKorisnikID { get; set; }
    public KorisnickiNalog IzmijenioKorisnik { get; set; }


    public DateTime? DatumUpdate { get; set; }

}