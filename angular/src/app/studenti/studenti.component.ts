import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {mojConfig} from "../moj_config";

@Component({
  selector: 'app-studenti',
  templateUrl: './studenti.component.html',
  styleUrls: ['./studenti.component.css']
})
export class StudentiComponent implements OnInit{
  filterStudent = "";
  studentPodaci:any = [];
  odabraniStudent: any;

  constructor(private httpKlijent : HttpClient) {
  }

  ngOnInit(): void {
    this.PreuzmiPodatke();
  }
  PreuzmiPodatke() {
    this.httpKlijent.get(mojConfig.adresaServera + "/Student/GetAll?ime_prezime=" + this.filterStudent).subscribe(x => {
      this.studentPodaci = x;
    });
  }
  getPodaci() {
    return this.studentPodaci.filter((x:any) => x.ime.toLowerCase().startsWith(this.filterStudent.toLowerCase()));
  }

  Snimi() {
    this.httpKlijent.post(mojConfig.adresaServera + "/Student/Snimi/",this.odabraniStudent).subscribe(x => {
    });
  }
}


