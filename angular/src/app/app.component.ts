import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'angular';

  ime = "";
  Podaci : any;

  dugme1() {
    this.ime = "ajdin V2";
  }

  PreuzmiPodatke() {

    let url = "https://localhost:7174/Predmet/GetAll?nazivFilter=" + this.ime ;
    fetch(url).
    then(
      r => {

        if (r.status !== 200) {
          alert("Server javlja gresku : " + r.status);
          return;
        }
        r.text().then(
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
