namespace FIT_Api_Example.Endpoints.Ispit.Dodaj
{
    public class IspitDodajRequest
    {
        public int PredmetId { get; set; }
        public DateTime Satnica { get; set; }
        public string Komentar { get; set; }
    }
}
