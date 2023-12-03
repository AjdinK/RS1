import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {MojConfig} from "../moj-config";
import {HttpClient} from "@angular/common/http";
import {MaticnaKnjigaVM} from "./maticna-knjiga-vm";

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
  maticnaKnjigaPodaci : MaticnaKnjigaVM;

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
    //'https://localhost:5001/MaticnaKnjigaDetalji/GetByID?studentId=74'
    this.httpKlijent.get<MaticnaKnjigaVM>(MojConfig.adresa_servera + "/MaticnaKnjigaDetalji/GetByID?studentId=" + this.odabraniStudentID , MojConfig.http_opcije()).subscribe((x:any) =>{
    this.maticnaKnjigaPodaci = x;
    });
  }

}
