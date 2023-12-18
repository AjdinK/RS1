namespace FIT_Api_Example.Endpoints.StudentEndpoints.MaticnaKnjigaEndpoints.Get;

public class StudentMaticnaKnjigaGetResponse
{
    public int Id { get; set; }
    public string Ime { get; set; }
    public string Prezime { get; set; }
    public List<StudentMaticnaKnjigaGetResponseUpisaneGodine> UpisaneGodine { get; set; }
}

public class StudentMaticnaKnjigaGetResponseUpisaneGodine
{
    public int Id { get; set; }
    public string AkademskaGodina { get; set; }
    public string GodinaStudija { get; set; }
    public bool Obnova { get; set; }
    public DateTime ZimskiSemestarUpis { get; set; }
    public DateTime? ZimskiSemestarOvjera { get; set; }
    public StudentMaticnaKnjigaGetResponseUpisaneGodineKorisnik KorisnikEvidentirao { get; set; }
}

public class StudentMaticnaKnjigaGetResponseUpisaneGodineKorisnik
{
    public int Id { get; set; }
    public string Ime { get; set; }
    public string Prezime { get; set; }
}
