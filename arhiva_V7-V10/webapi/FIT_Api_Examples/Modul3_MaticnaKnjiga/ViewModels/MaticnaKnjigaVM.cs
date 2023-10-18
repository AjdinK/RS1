using FIT_Api_Examples.Modul3_MaticnaKnjiga.Models;
using System.Collections.Generic;

namespace FIT_Api_Examples.Modul3_MaticnaKnjiga.ViewModels
{
    public class MaticnaKnjigaVM
    {
        public int id { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public List<ListaUpisi> listaUpisi { get; set; }
        public float cijenaSkolarina { get; set; }
    }
}
