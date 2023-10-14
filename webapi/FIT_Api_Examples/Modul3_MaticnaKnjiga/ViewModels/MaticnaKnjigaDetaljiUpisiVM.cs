using FIT_Api_Examples.Modul2.Models;
using System;
using System.Collections.Generic;

namespace FIT_Api_Examples.Modul3_MaticnaKnjiga.ViewModels
{
    public class MaticnaKnjigaDetaljiUpisiVM
    {
        public object upisAkademskeGodineId { get; set; }
        public object akademskaGodinaOpis { get; set; }
        public object godinaStudija { get; set; }
        public object obnova { get; set; }
        public DateTime? zimskiSemsterUpis { get; set; }
        public DateTime? zimskiSemsterOvjera { get; set; }
        public string evidentiraoKorisnik { get; set; }
    }
}
