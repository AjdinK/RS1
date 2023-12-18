import { Component, OnInit } from '@angular/core';
import {MojConfig} from "../../moj-config";
import {HttpClient} from "@angular/common/http";
import {StudentSnimiEndpoint, StudentSnimiRequest} from "../../endpoints/student-endpoints/student-snimi.endpoint";
import {
  Student6PretragaResponse,
  Student6PretragaResponseStudenti,
  StudentGetAllEndpoint
} from "../../endpoints/student-endpoints/student-getall.endpoint";
import {
  OpstineGetAllEndpoint,
  OpstineGetAllResponseOpstina
} from "../../endpoints/opstine-endpoints/opstine-getall.endpoint";

@Component({
  selector: 'app-sedmica6-edit',
  templateUrl: './sedmica6-edit.component.html',
  styleUrls: ['./sedmica6-edit.component.css']
})
export class Sedmica6EditComponent implements OnInit {
  public studenti:Student6PretragaResponseStudenti[]=[];
  public odabraniStudent: StudentSnimiRequest | null = null;
  modalTitle = "Edit student";
  public opstine: OpstineGetAllResponseOpstina[] = [];
  public pretragaNaziv: string="";

  constructor(
    private snimiEndpoint:StudentSnimiEndpoint,
    private getAllEndpoint:StudentGetAllEndpoint,
    private opstineGetAllEndpoint: OpstineGetAllEndpoint
    ) { }

  ngOnInit(): void {
    let url=MojConfig.adresa_servera+`/student/pretraga`;
    this.getAllEndpoint.obradi().subscribe({
      next: x =>{
        this.studenti=x.studenti;
      },
      error: x =>{
        alert("greska: " + x.error)
      }
    })

    this.opstineGetAllEndpoint
      .obradi()
      .subscribe({
        next: x=>{
          this.opstine = x.opstine;
        }
      })
  }

  odaberi(item: Student6PretragaResponseStudenti) {
    this.odabraniStudent = {
      ime: item.ime,
      prezime: item.prezime,
      id: item.id,
      opstinaRodjenjaID: item.opstinaRodjenjaID
    } ;
  }
  getFiltriraniStudetni() {
    return this.studenti
      .filter(x=>

        (x.ime + ' ' + x.prezime).startsWith(this.pretragaNaziv) || (x.prezime + ' ' + x.ime).startsWith(this.pretragaNaziv) || x.opstinaRodjenjaNaziv.toLowerCase().startsWith(this.pretragaNaziv.toLowerCase())

      )
  }

  snimi(): void {

    this.snimiEndpoint.obradi(this.odabraniStudent!).subscribe((x)=>{
      alert("uredu")
      this.ngOnInit();
      this.odabraniStudent = null
    })
  }

  zatvori() {
    this.odabraniStudent = null;
  }
}
