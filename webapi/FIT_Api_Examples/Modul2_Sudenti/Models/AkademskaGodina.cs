﻿using System;
using System.ComponentModel.DataAnnotations;
using FIT_Api_Examples.Modul0_Autentifikacija.Models;

namespace FIT_Api_Examples.Modul2.Models
{
    public class AkademskaGodina
    {
        [Key]
        public int id { get; set; }
        public string opis { get; set; } = string.Empty;
        public KorisnickiNalog? evidentiraoKorisnik { get; set; }
        public KorisnickiNalog? izmijenioKorisnik { get; set; }
        public DateTime? datum_update { get; set; }
        public DateTime datum_added { get; set; }
    }
}
