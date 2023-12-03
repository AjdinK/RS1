namespace FIT_Api_Example.Endpoints.Ispit.Pretraga
{
    public class IspitPretragaResponse
    {
        public List<IspitPretragaResponseIspit> Ispiti { get; set; }
    }

    public class IspitPretragaResponseIspit
    {
        public int IdIspita { get; set; }
        public string Komnt { get; set; }
        public DateTime Satnica { get; set; }
        public int PredmetId { get; set; }
        public string PuniNaziv { get; set; }
        public string SifraPredmeta { get; set; }
        public int Bodovi { get; set; }

        public string Opis => PuniNaziv + ": " + SifraPredmeta;
    }
}
