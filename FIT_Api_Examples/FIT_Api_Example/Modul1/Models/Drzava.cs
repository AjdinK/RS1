﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Example.Modul1.Models
{
    public class Drzava
    { 
        [Key]
        public int ID { get; set; }
        public string Naziv { get; set; }
        public string? Skracenica { get; set; }
    }
}
