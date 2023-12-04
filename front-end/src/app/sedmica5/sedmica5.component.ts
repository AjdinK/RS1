import { Component, OnInit } from '@angular/core';
import {MojConfig} from "../moj-config";
import {StudentOldGetAllResponse} from "./student-old-get-all-response";

@Component({
  selector: 'app-sedmica5',
  templateUrl: './sedmica5.component.html',
  styleUrls: ['./sedmica5.component.css']
})
export class Sedmica5Component implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  studenti: StudentOldGetAllResponse[] = [];

  getStudenti() {
    let url = MojConfig.adresa_servera +`/Student/GetAll`
    fetch(url)
      .then(response=>{
        if (response.status != 200)
        {
            alert("greska... " + response.statusText);
            return;
        }
        response.json().then(d=>{
          this.studenti = d;
        })
      })
  }
}
