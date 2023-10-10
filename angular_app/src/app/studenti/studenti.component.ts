import { Component, OnInit } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {MojConfig} from "../moj-config";
import {Router} from "@angular/router";
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
  studentPodaci: any;
  odabraniStudent: any;
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
  }

  ngOnInit(): void {
    this.testirajWebApi();
  }

  fetchStudenti() {
    this.httpKlijent.get(MojConfig.adresa_servera+ "/Student/GetAll", MojConfig.http_opcije()).subscribe(x=>{
      this.studentPodaci = x;
    });
  }
  fetchOpstine() {
    //https://localhost:5001/Opstina/GetByAll
    this.httpKlijent.get(MojConfig.adresa_servera + "/Opstina/GetByAll" , MojConfig.http_opcije()).subscribe(x=>{
      this.opstinePodaci = x;
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
      broj_indeks:0,
    }
  }

  snimiDugme() {
    this.httpKlijent.post(MojConfig.adresa_servera + "/Student/Snimi" , this.odabraniStudent ,MojConfig.http_opcije()).subscribe((x:any)=>{
      porukaSuccess("Uspjesano Snimljeno");
      this.fetchStudenti();
      this.odabraniStudent = null;
    })

  }
//https://localhost:5001/Student/Brisi?id=108
  Brisi(id:number) {
    this.httpKlijent.delete(MojConfig.adresa_servera + "/Student/Brisi?id=" + id , MojConfig.http_opcije()).subscribe((x:any)=>{
      porukaSuccess("Uspjesano Izbriat");
      this.fetchStudenti();
    });

  }

  MaticnaKnjigaDugme(s: any) {

  }

  UrediDugme(s:any) {
    this.odabraniStudent = s;

  }
}
