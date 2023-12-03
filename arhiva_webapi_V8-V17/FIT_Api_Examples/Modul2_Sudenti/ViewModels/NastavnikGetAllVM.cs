namespace FIT_Api_Examples.Modul2.ViewModels
{
    public class NastavnikVM
    {
        public int Id { get; set; }
        public string Ime { get; set; } = string.Empty;
        public string Prezime { get; set; } = string.Empty;
        public string KorisnickoIme { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        
        // public string vrijeme_dodavanja { get; set; }
        // public string? slika_korisnika_nova_base64 { get;  set; }
        // public byte[]? slika_korisnika_postojeca_base64_DB { get; set; }
        // public byte[]? slika_korisnika_postojeca_base64_FS { get; set; }
    }
}
