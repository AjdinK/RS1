import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {StudentSedmica5Response} from "../sedmica5/student-sedmica5-response";
import {MojConfig} from "../moj-config";
import {StudentiGetAllResponse, StudentiGetAllResponseStudent} from "./studenti-getall-response";

@Component({
  selector: 'app-sedmica5-pretraga-js',
  templateUrl: './sedmica5-pretraga-js.component.html',
  styleUrls: ['./sedmica5-pretraga-js.component.css']
})
export class Sedmica5PretragaJsComponent implements OnInit {

  constructor(public httpClient: HttpClient ) {
  }
  studenti: StudentiGetAllResponseStudent[] = [];
  pretragaNaziv="";
  ngOnInit(): void {
    let url = MojConfig.adresa_servera +`/student/get-all`
    this.httpClient.get<StudentiGetAllResponse>(url).subscribe((x:StudentiGetAllResponse)=>{
      this.studenti = x.studenti;
    })
  }

  getFiltriraniStudetni() {
    return this.studenti.filter(x=>(x.ime + ' ' + x.prezime).startsWith(this.pretragaNaziv) || (x.prezime + ' ' + x.ime).startsWith(this.pretragaNaziv))
  }
}
