using FIT_Api_Examples.Modul2.Models;
using System;
using System.Collections.Generic;

namespace FIT_Api_Examples.Modul3_MaticnaKnjiga.ViewModels
{
    public class MaticnaKnjigaDetaljiUpisiVM
    {
        public object upisAkademskeGodineId { get; internal set; }
        public object akademskaGodinaOpis { get; internal set; }
        public object godinaStudija { get; internal set; }
        public object obnova { get; internal set; }
        public DateTime? zimskiSemsterUpis { get; set; }
        public DateTime? zimskiSemsterOvjera { get; set; }
        public string evidentiraoKorisnik { get; set; }
    }
}
