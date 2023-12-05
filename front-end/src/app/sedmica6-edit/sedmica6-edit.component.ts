import { Component, OnInit } from '@angular/core';
import {MojConfig} from "../moj-config";
import {HttpClient} from "@angular/common/http";
import {Student6PretragaResponse, Student6PretragaResponseStudenti} from "./student6-getall";
import {StudentSnimiRequest} from "./student-snimi-request";

@Component({
  selector: 'app-sedmica6-edit',
  templateUrl: './sedmica6-edit.component.html',
  styleUrls: ['./sedmica6-edit.component.css']
})
export class Sedmica6EditComponent implements OnInit {
  public studenti:Student6PretragaResponseStudenti[]=[];
  public odabraniStudent: StudentSnimiRequest | null = null;
  constructor(public httpClient:HttpClient) { }

  ngOnInit(): void {
    let url=MojConfig.adresa_servera+`/student/pretraga`;
    this.httpClient.get<Student6PretragaResponse>(url).subscribe((x:Student6PretragaResponse)=>{
      this.studenti=x.studenti;
    })
  }

  odaberi(item: Student6PretragaResponseStudenti) {
    this.odabraniStudent = {
      ime: item.ime,
      prezime: item.prezime,
      id: item.id
    } ;
  }


  snimi(): void {
    let url=MojConfig.adresa_servera+`/student/snimi`;
    this.httpClient.post(url, this.odabraniStudent).subscribe((x)=>{
      alert("uredu")
      this.ngOnInit();
      this.odabraniStudent = null
    })
  }
}
