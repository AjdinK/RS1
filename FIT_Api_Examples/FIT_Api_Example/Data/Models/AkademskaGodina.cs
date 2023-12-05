using System.ComponentModel.DataAnnotations;

namespace FIT_Api_Example.Data.Models;

public class AkademskaGodina
{
    [Key]
    public int ID { get; set; }
    public string Opis { get; set; }
}