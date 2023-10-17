namespace FIT_Api_Examples.Modul3_MaticnaKnjiga.Models
{
    public class ListaUpisi
    {
        public int id { get; set; }
        public int godinaStudija { get; set; }
        public bool jelObnova { get; set; }
        public string datumUpisZimski { get; set; }
        public float cijenaSkolarine { get; set; }
        public string datumOvjeraZimski { get; set; }
        public string evidentirao_korisnik { get; set; }
        public string akademska_godina_opis { get; set; }
        public int akademska_godina_id { get; set; }
    }
}
