using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Example.Data.Models;

[Table("Nastavnik")]// ako obrisemo -onda se koristi TPH
public class Nastavnik : KorisnickiNalog
{
    public string Ime { get; set; }
    public string Prezime { get; set; }

}