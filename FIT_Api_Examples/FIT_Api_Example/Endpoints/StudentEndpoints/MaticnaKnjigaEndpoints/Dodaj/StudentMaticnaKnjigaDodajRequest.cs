namespace FIT_Api_Example.Endpoints.StudentEndpoints.MaticnaKnjigaEndpoints.Dodaj
{
    public class StudentMaticnaKnjigaDodajRequest
    {
        public int StudentID { get; set; }
        public int AkademskaGodinaID { get; set; }
        public int GodinaStudija { get; set; }
        public bool Obnova { get; set; }
        public DateTime ZimskiSemestarUpis { get; set; }
        public float CijenaSkolarine { get; set; }
    }
}
