using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FIT_Api_Examples.Modul5_OnlineTestovi.Models
{
    public class PitanjaPonudjeneOpcije
    {
        public int Id { get; set; }
        public string Opis { get; set; } = string.Empty;

        [JsonIgnore]
        public bool JelTacno { get; set; }

        [ForeignKey(nameof(PitanjaId))]
        [JsonIgnore]
        public Pitanje Pitanje { get; set; } = null!;
        public int PitanjaId { get; set; }

    }
}