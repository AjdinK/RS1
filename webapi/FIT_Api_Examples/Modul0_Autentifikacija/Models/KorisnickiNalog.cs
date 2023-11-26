using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;
using FIT_Api_Examples.Modul2.Models;
using FIT_Api_Examples.Modul3_MaticnaKnjiga.Models;

namespace FIT_Api_Examples.Modul0_Autentifikacija.Models
{
    [Table("KorisnickiNalog")]
    public class KorisnickiNalog
    {
        [Key]
        public int Id { get; set; }
        public string KorisnickoIme { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Ime { get; set; } = string.Empty;
        public string Prezime { get; set; } = string.Empty;
        public DateTime CreatedTime { get; set; }
        public byte[]? slika_korisnika_bajtovi { get; set; }

        public bool isAdmin { get; set; }
        public bool isProdekan { get; set; }
        public bool isDekan { get; set; }
        public bool isStudentskaSluzba { get; set; }
        public bool isAktiviran { get; set; }
        public string? AktivacijaGUID { get; set; }



        [JsonIgnore]
        public string Lozinka { get; set; } = string.Empty;



        public bool isNastavnik => Nastavnik != null;
        public bool isStudent => Student != null;

        [JsonIgnore]
        public Student? Student => this as Student;

        [JsonIgnore]
        public Nastavnik? Nastavnik => this as Nastavnik;
    }
}
