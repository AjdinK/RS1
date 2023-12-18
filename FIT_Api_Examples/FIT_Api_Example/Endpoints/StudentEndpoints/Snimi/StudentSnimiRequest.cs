namespace FIT_Api_Example.Endpoints.StudentEndpoints.Snimi;

public class StudentSnimiRequest
{
    public int ID { get; set; }
    public string Ime { get; set; }
    public string Prezime { get; set; }
    //public string BrojIndeksa { get; set; }
    public int OpstinaRodjenjaID { get; set; }
    //public DateTime DatumRodjenja { get; set; }
}