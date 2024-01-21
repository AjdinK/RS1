using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FIT_Api_Example.Data.Models;

public class AutentifikacijaToken
{
    [Key]
    public int ID { get; set; }
    public string Vrijednost { get; set; }
    public DateTime VrijemeEvidentiranja { get; set; }
    public string? IpAdresa { get; set; }

    [JsonIgnore]
    public string? TwoFKey { get; set; }
    public bool Is2FOtkljucano { get; set; }

    [ForeignKey (nameof(KorisnickiNalog))]
    public int KorisnickiNalogId { get; set; }
    public KorisnickiNalog KorisnickiNalog { get; set; }
}