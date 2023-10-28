namespace FIT_Api_Examples.Modul2.ViewModels
{
    public class NastavnikGetAllVM
    {
        public int id { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public string korisnickoIme { get; set; }
        public string Email { get; set; }
        public string vrijeme_dodavanja { get; set; }
        public string? slika_korisnika_nova_base64 { get;  set; }
        public byte[]? slika_korisnika_postojeca_base64_DB { get; set; }
        public byte[]? slika_korisnika_postojeca_base64_FS { get; set; }
    }
}
