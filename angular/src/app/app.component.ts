import { Component } from '@angular/core';
import {mojConfig} from "./moj_config";
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  title = 'angular';
  filterPredmet = "";
  Podaci:any[] = [];
  odabraniPredmet: any;
  ime = "ajdin";

  constructor(private httpKlijent :HttpClient) {
  }

  PreuzmiPodatke() {

    fetch(mojConfig.adresaServera + "/Predmet/GetAll?nazivFilter=" + this.filterPredmet ).
    then(
      r => {

        if (r.status !== 200) {
          alert("Server javlja gresku : " + r.status);
          return;
        }
        r.json().then(
          t => {
          this.Podaci = t;
        });
      }

    ).catch(
      err => {
        alert("Greska u komunikaciji sa serverom : " + err);
      }
    );
  }

}
