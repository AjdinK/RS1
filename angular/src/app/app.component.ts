import { Component } from '@angular/core';

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

  PreuzmiPodatke() {

    let url = "https://localhost:7174/Predmet/GetAll?nazivFilter=" + this.filterPredmet ;
    fetch(url).
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
