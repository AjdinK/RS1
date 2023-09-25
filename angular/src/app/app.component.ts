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
  filterPredmet = "";
  Podaci:any = [];
  odabraniPredmet: any;

  constructor(private httpKlijent : HttpClient) {
  }

  ngOnInit(): void {
       this.PreuzmiPodatke();
    }

  PreuzmiPodatke() {
    this.httpKlijent.get(mojConfig.adresaServera + "/Predmet/GetAll?nazivFilter=" + this.filterPredmet).subscribe(x => {
      this.Podaci = x;
    });
  }

}
