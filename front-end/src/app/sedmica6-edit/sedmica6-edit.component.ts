import { Component, OnInit } from '@angular/core';
import {MojConfig} from "../moj-config";
import {HttpClient} from "@angular/common/http";
import {StudentSnimiEndpoint, StudentSnimiRequest} from "../endpoints/student-endpoints/student-snimi.endpoint";
import {
  Student6PretragaResponse,
  Student6PretragaResponseStudenti,
  StudentGetAllEndpoint
} from "../endpoints/student-endpoints/student-getall.endpoint";

@Component({
  selector: 'app-sedmica6-edit',
  templateUrl: './sedmica6-edit.component.html',
  styleUrls: ['./sedmica6-edit.component.css']
})
export class Sedmica6EditComponent implements OnInit {
  public studenti:Student6PretragaResponseStudenti[]=[];
  public odabraniStudent: StudentSnimiRequest | null = null;
  constructor(
    private snimiEndpoint:StudentSnimiEndpoint,
    private getAllEndpoint:StudentGetAllEndpoint
    ) { }

  ngOnInit(): void {
    let url=MojConfig.adresa_servera+`/student/pretraga`;
    this.getAllEndpoint.obradi().subscribe((x:Student6PretragaResponse)=>{
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

    this.snimiEndpoint.obradi(this.odabraniStudent!).subscribe((x)=>{
      alert("uredu")
      this.ngOnInit();
      this.odabraniStudent = null
    })
  }
}
