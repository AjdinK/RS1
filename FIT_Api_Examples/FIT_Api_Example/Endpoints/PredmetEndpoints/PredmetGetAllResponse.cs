namespace FIT_Api_Example.Endpoints.PredmetEndpoints;

public class PredmetGetAllResponse
{
    public int ID { get; set; }
    public string Naziv { get; set; }
    public string ECTS { get; set; }
    public string Sifra { get; set; }
    public double? ProsjecnaOcjena { get; set; }
}