import { Component, OnInit } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {MojConfig} from "../moj-config";
import {Router} from "@angular/router";
import { StudentGetAllVM } from './student-getall-vm';
declare function porukaSuccess(a: string):any;
declare function porukaError(a: string):any;

@Component({
  selector: 'app-studenti',
  templateUrl: './studenti.component.html',
  styleUrls: ['./studenti.component.css']
})
export class StudentiComponent implements OnInit {

  title:string = 'angularFIT2';
  ime_prezime:string = '';
  filter_ime_prezime: boolean;
  studentPodaci: StudentGetAllVM [] = [];
  odabraniStudent: StudentGetAllVM ;
  opstina: string = '';
  filter_opstina: boolean;
  opstinePodaci : any;
  akademskaGodinaPodaci : any;
  constructor(private httpKlijent: HttpClient, private router: Router) {
  }

  testirajWebApi() :void
  {
  this.fetchStudenti();
  this.fetchOpstine();
  this.fetchAkademskeGodine()
  }

  ngOnInit(): void {
    this.testirajWebApi();
  }

  fetchStudenti() {
    this.httpKlijent.get<StudentGetAllVM>(MojConfig.adresa_servera+ "/Student/GetAll", MojConfig.http_opcije()).subscribe((x:any)=>{
      this.studentPodaci = x;
    });
  }
  fetchOpstine() {
    //https://localhost:5001/Opstina/GetByAll
    this.httpKlijent.get(MojConfig.adresa_servera + "/Opstina/GetByAll" , MojConfig.http_opcije()).subscribe(x=>{
      this.opstinePodaci = x;
    });
  }
  fetchAkademskeGodine () {
    //https://localhost:5001/AkademskeGodine/GetAll_ForCmb
    this.httpKlijent.get(MojConfig.adresa_servera + "/AkademskeGodine/GetAll").subscribe((x:any)=>{
      this.akademskaGodinaPodaci = x;
    });

  }
  getPodaci() {
    if (this.studentPodaci == null)
      return [];

    return this.studentPodaci.filter((s:any)=>
      (!this.filter_ime_prezime ||
        (s.ime.toLowerCase() + " " + s.prezime.toLowerCase()).startsWith(this.ime_prezime.toLowerCase()) ||
        (s.prezime.toLowerCase() + " " + s.ime.toLowerCase()).startsWith(this.ime_prezime.toLowerCase()))

      &&
      (!this.filter_opstina ||
        (s.opstina_rodjenja.description.toLowerCase()).startsWith(this.opstina.toLowerCase())));

  }
  noviStudent() {
    this.odabraniStudent = {
      id:0,
      ime:this.ime_prezime,
      prezime:'',
      broj_indeksa:"",
      opstina_rodjenja_id : 2,
      created_time: "",
      opstina_rodjenja_opis : "",
      drzava_rodjeja_opis : "",
      vrijeme_dodavanje : "",
      slika_korisnika : "",
    }
  }

  snimiDugme() {
    this.httpKlijent.post(MojConfig.adresa_servera + "/Student/Snimi" , this.odabraniStudent ,MojConfig.http_opcije()).subscribe((x:any)=>{
      porukaSuccess("Uspjesano Snimljeno");
      this.fetchStudenti();
      this.odabraniStudent = null;
    })
  }

  MaticnaKnjigaDugme(s: StudentGetAllVM) {
    this.router.navigate(["/student-maticnaknjiga",s.id]);
  }

  UrediDugme(s:StudentGetAllVM) {
    this.odabraniStudent = s;
  }

  ObrisiDugmeByID(id:number) {
    'https://localhost:5001/Student/BrisiByID?id=82'
    this.httpKlijent.delete(MojConfig.adresa_servera + "/Student/BrisiByID?id=" + id , MojConfig.http_opcije()).subscribe((x:any)=>{
      this.fetchStudenti();
    })
  }

  ObrisiDugmeByObj(s:StudentGetAllVM) {
    //https://localhost:5001/Student/BrisiByObj
    this.httpKlijent.post(MojConfig.adresa_servera + "/Student/BrisiByObj" , s , MojConfig.http_opcije()).subscribe((x:any)=>{
      this.fetchStudenti();
    })
  }

}
