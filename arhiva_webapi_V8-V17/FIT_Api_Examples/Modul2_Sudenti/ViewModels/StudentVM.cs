namespace FIT_Api_Examples.Modul2.ViewModels
{
    public class StudentVM
    {
        public int Id { get; set; }
        public string Ime { get; set; } = string.Empty;
        public string Prezime { get; set; } = string.Empty;
        public int? OpstinaRodjenjaId { get; set; }
        public string? OpstinaRodjenjaOpis { get; set; }
        public string BrojIndeksa { get; set; } = string.Empty;
        public string DrzavaRodjenjaOpis { get; set; } = string.Empty;
        public string CreatedTime { get; set; } = string.Empty;
        public int[]? OmiljeniPredmeti { get; set; }

        public string? SlikaKorisnikaNovaBase64 { get; set; }
        public byte[]? SlikaKorisnikaPostojecaBase64DB { get; set; }
        public byte[]? SlikaKorisnikaPostojecaBase64FS { get; set; }
    }
}
