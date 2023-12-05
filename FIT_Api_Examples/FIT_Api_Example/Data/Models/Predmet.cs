using System.ComponentModel.DataAnnotations;

namespace FIT_Api_Example.Data.Models;

public class Predmet
{
    [Key]
    public int ID { get; set; }
    public string Naziv { get; set; }
    public string Sifra { get; set; }
    public int Ects { get; set; }

}