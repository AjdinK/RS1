﻿using FIT_Api_Example.Helper;

namespace FIT_Api_Example.Endpoints.StudentEndpoints.GetAll;

public class StudentGetAllResponse
{
    public List<StudentGetAllResponseStudent> Studenti { get; set; }
}

public class StudentGetAllResponseStudent
{
    public int ID { get; set; }
    public string Ime { get; set; }
    public string Prezime { get; set; }
    public string OpstinaRodjenjaNaziv { get; set; }
    public string OpstinaRodjenjaDrzava { get; set; }
    public int OpstinaRodjenjaID { get; set; }
    public DateTime DatumRodjenja { get; set; }
    public string KorisnickoIme { get; set; }
    public string SlikaKorisnika { get; set; }
}