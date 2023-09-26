import {Component, OnInit} from '@angular/core';
import {mojConfig} from "./moj_config";
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{

  title = 'angular';
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
      this.studentPodaci = x;
    });
  }
}
