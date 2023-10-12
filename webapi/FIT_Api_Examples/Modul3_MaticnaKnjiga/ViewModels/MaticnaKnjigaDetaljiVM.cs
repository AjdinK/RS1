using FIT_Api_Examples.Modul2.Models;
using System.Collections.Generic;

namespace FIT_Api_Examples.Modul3_MaticnaKnjiga.ViewModels
{
    public class MaticnaKnjigaDetaljiVM
    {
        public int studentID { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public List<MaticnaKnjigaDetaljiUpisiVM> AkGodine { get; set; }

    }
}
