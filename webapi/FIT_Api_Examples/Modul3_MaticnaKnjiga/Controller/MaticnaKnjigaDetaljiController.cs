﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FIT_Api_Examples.Data;
using FIT_Api_Examples.Helper;
using FIT_Api_Examples.Helper.AutentifikacijaAutorizacija;
using FIT_Api_Examples.Modul0_Autentifikacija.Models;
using FIT_Api_Examples.Modul2.Models;
using FIT_Api_Examples.Modul2.ViewModels;
using FIT_Api_Examples.Modul3_MaticnaKnjiga.Models;
using FIT_Api_Examples.Modul3_MaticnaKnjiga.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIT_Api_Examples.Modul2.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class MaticnaKnjigaDetaljiController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public MaticnaKnjigaDetaljiController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        // [HttpGet]
        // public ActionResult<MaticnaKnjigaDetaljiVM> GetByID(int studentID)
        // {
        //     var objStudent = _dbContext.Student.Find(studentID);

        //     var rez = new MaticnaKnjigaDetaljiVM
        //     {
        //         studentID = studentID,
        //         ime = objStudent.ime,
        //         prezime = objStudent.prezime,
        //         AkGodine = _dbContext.UpisAkGodine.Where(s => s.StudentID == studentID).ToList()
        //         .Select(u => new MaticnaKnjigaDetaljiUpisiVM
        //         {
        //             upisAkademskeGodineId = u.Id,
        //             akademskaGodinaOpis = u.AkademskaGodina.opis,
        //             godinaStudija = u.GodinaStudija,
        //             obnova = u.JelObnova,
        //             zimskiSemsterUpis = u.DatumUpisZimski,
        //             zimskiSemsterOvjera = u.DatumOvjeraZimski,
        //             evidentiraoKorisnik = u.EvidentiraoKorisnik.korisnickoIme,
        //             // npr brojPolozenihPredmeta ili ListaPolozeniPredmeti
        //             // ili uplate ... itd 
        //             // ili prosjecna ocjena ... itd

        //         }).ToList(),
        //     };
        //     return rez;
        // }

    [HttpGet]
    public ActionResult GetByID(int studentId) {

            var upisAkGodine = _dbContext.UpisAkGodine
                .Where(s => s.Student.id == studentId)
                .Select(u => new { 
                    u.Id,
                    u.GodinaStudija,
                    u.JelObnova,
                    u.DatumUpisZimski,
                    u.CijenaSkolarine,
                    u.DatumOvjeraZimski,
                    evidentirao_korisnik = u.EvidentiraoKorisnik.korisnickoIme,
                    akademska_godina_opis = u.AkademskaGodina.opis,
                    akademska_godina_id = u.AkademskaGodinaID,
                });

            var povretna = _dbContext.Student
                    .Where(s => s.id == studentId)
                    .Select(s => new {
                        s.id,
                        s.ime,
                        s.prezime,
                        listaUpisi = upisAkGodine.ToList(),
                        cijenaSkolarina = upisAkGodine
                        .Sum(s => s.CijenaSkolarine
                        )
                    }).FirstOrDefault();

            return Ok(povretna);

        }

    }
}

