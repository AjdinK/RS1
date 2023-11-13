namespace FIT_Api_Examples.Modul2.ViewModels
{
    public class StudentVM
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int? OpstinaRodjenjaId { get; set; }
        public string? OpstinaRodjenjaOpis { get; set; }
        public string BrojIndeksa { get; set; }
        public string DrzavaRodjenjaOpis { get; set; }
        public string Created_Time { get; set; }
        public int[]? OmiljeniPredmeti { get; set; }

        public string? SlikaKorisnikaNovaBase64 { get; set; }
        public byte[]? SlikaKorisnikaPostojecaBase64DB { get; set; }
        public byte[]? SlikaKorisnikaPostojecaBase64FS { get; set; }
    }
}
