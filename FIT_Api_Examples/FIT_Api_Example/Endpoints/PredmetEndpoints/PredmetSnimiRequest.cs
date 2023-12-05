namespace FIT_Api_Example.Endpoints.PredmetEndpoints;

public class PredmetSnimiRequest
{
    public int Id { get; set; }
    public string Sifra { get; set; }
    public string Naziv { get; set; }
    public int Ects { get; set; }
}