using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FIT_Api_Examples.Modul5_OnlineTestovi.Models
{
    public class StudentTestPitanja
    {
        public int Id { get; set; }
        public float MaxBodovi { get; set; }
        public float OstvareniBodovi { get; set; }


        [ForeignKey(nameof(StudentTestId))]
        [JsonIgnore]
        public virtual StudentTest StudentTest { get; set; } = null!;
        public int StudentTestId { get; set; }


        [ForeignKey(nameof(PitanjeId))]
        public virtual Pitanje Pitanje { get; set; } = null!;
        public int PitanjeId { get; set; }


        [JsonIgnore]
        public string? OznaceniOdgovoriIDsString { get; set; }

        [NotMapped]
        public List<int> OznaceniOdgovoriIDs
        {
            get => JsonSerializer.Deserialize<List<int>>(OznaceniOdgovoriIDsString ?? "[]") ?? new List<int>();
            set => OznaceniOdgovoriIDsString = JsonSerializer.Serialize(value);
        }

        //public virtual List <PitanjaPonudjeneOpcije> OznaceniOdgovoriIDs2 {get;set;} = new List<PitanjaPonudjeneOpcije>(); 
    }
}