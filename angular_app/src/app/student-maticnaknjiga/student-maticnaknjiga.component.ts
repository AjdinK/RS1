import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {MojConfig} from "../moj-config";
import {HttpClient} from "@angular/common/http";

declare function porukaSuccess(a: string):any;
declare function porukaError(a: string):any;

@Component({
  selector: 'app-student-maticnaknjiga',
  templateUrl: './student-maticnaknjiga.component.html',
  styleUrls: ['./student-maticnaknjiga.component.css']
})
export class StudentMaticnaknjigaComponent implements OnInit {

  constructor(private httpKlijent: HttpClient, private route: ActivatedRoute) {}
  odabraniStudentID:number ;
  maticnaKnjigaPodaci : any;

  ovjeriLjetni(s:any) {

  }

  upisLjetni(s:any) {

  }

  ovjeriZimski(s:any) {

  }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.odabraniStudentID = + params ['id'];
    })
    this.fetchMaticnaKnjigaDetalji();
  }

  fetchMaticnaKnjigaDetalji() {
    //https://localhost:5001/MaticnaKnjigaDetalji/GetByID?studentID=13
    this.httpKlijent.get(MojConfig.adresa_servera + "/MaticnaKnjigaDetalji/GetByID?studentID=" + this.odabraniStudentID , MojConfig.http_opcije()).subscribe((x:any) =>{
    this.maticnaKnjigaPodaci = x;
    });
  }

}
