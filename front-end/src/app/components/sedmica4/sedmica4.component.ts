import { Component, OnInit } from '@angular/core';
import {Router} from "@angular/router";

@Component({
  selector: 'app-sedmica4',
  templateUrl: './sedmica4.component.html',
  styleUrls: ['./sedmica4.component.css']
})
export class Sedmica4Component {
  constructor(public router : Router) {
  }

  title = 'front-end';

  imena = [];

  brojac=0;
  ime = "Adil";
  novoIme="";

  uvecaj(){
    this.brojac++;
    this.ime = this.ime + "."
  }

  testirajDugme2(){

    alert("hello FIT...." + this.brojac)
  }

  izmjenaImena($event: Event) {
    // @ts-ignore
    this.ime = $event.target.value
  }

  isVidljiv() {
    return this.brojac > 5
  }

  styleZaDiv() {
    if (this.brojac == 7) {
      return {
        backgroundColor: 'yellow'
      };
    }
    else
    {
      return  {
        backgroundColor:'blue'
      };
    }
  }

  dodajNovoIme() {
    // @ts-ignore
    this.imena.push(this.novoIme);
  }

  dugme (componentNaziv : string) {
    this.router.navigate([componentNaziv]);

  }

}
