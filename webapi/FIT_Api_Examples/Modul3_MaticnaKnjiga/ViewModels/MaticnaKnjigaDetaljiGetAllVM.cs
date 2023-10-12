namespace FIT_Api_Examples.Modul3_MaticnaKnjiga.ViewModels
{
    public class MaticnaKnjigaDetaljiGetAllVM
    {
        public string ime { get; set; }
        public string prezime { get; set; }
        public int? opstina_rodjenja_id { get; set; }
        public int id { get; internal set; }
        public string opstina_rodjenja_opis { get; set; }
        public int prosjecnaOcjena { get; set; }
        public int brojPolozenihPredmeta { get; set; }
    }
}
