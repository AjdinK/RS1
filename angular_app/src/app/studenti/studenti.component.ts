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
  opstina: string = '';
  studentPodaci: any;
  filter_ime_prezime: boolean;
  filter_opstina: boolean;
  odabraniStudent: any;


  constructor(private httpKlijent: HttpClient, private router: Router) {
  }

  testirajWebApi() :void
  {
    this.httpKlijent.get(MojConfig.adresa_servera+ "/Student/GetAll", MojConfig.http_opcije()).subscribe(x=>{
      this.studentPodaci = x;
    });
  }

  ngOnInit(): void {
    this.testirajWebApi();
  }

  getPodaci() {

    return this.studentPodaci.filter((s:any)=>
      (!this.filter_ime_prezime ||
        (s.ime.toLowerCase() + " " + s.prezime.toLowerCase()).startsWith(this.ime_prezime.toLowerCase()) ||
        (s.prezime.toLowerCase() + " " + s.ime.toLowerCase()).startsWith(this.ime_prezime.toLowerCase()))

      &&
      (!this.filter_opstina ||
        (s.opstina_rodjenja.description.toLowerCase()).startsWith(this.opstina.toLowerCase())));

  }
}
