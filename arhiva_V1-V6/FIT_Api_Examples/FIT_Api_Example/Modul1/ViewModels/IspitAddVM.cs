using FIT_Api_Example.Modul1.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Example.Modul1.ViewModels
{
    public class IspitAddVM
    {
        public string Naziv { get; set; }
        public DateTime Datum { get; set; }
        public int PredmetID { get; set; }
    }

}
