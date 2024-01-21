using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FIT_Api_Example.Data.Models;

[Table("KorisnickiNalog")]
public abstract class KorisnickiNalog
{
    [Key]
    public int ID { get; set; }
    public string Ime { get; set; }
    public string Prezime { get; set; }
    public string KorisnickoIme { get; set; }
    public string? SlikaKorisnika { get; set; }
    public string? SlikaKorisnikaMala { get; set; }
    public string? SlikaKorisnikaVelika { get; set; }
    public DateTime DatumRodjenja { get; set; }

    public bool IsAdmin { get; set; }
    public bool IsProdekan { get; set; }
    public bool IsDekan { get; set; }
    public bool IsStudentskaSluzba { get; set; }
    public bool Is2FActive { get; set; }

    [JsonIgnore]
    public string Lozinka { get; set; }

    [JsonIgnore]
    public Student? Student => this as Student;
    public bool IsStudent => Student != null;

    [JsonIgnore]
    public Nastavnik? Nastavnik => this as Nastavnik;
    public bool IsNastavnik => Nastavnik != null;

}