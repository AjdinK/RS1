import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {
  StudentMaticnaKnjigaGetEndpoint, StudentMaticnaKnjigaGetResponse, StudentMaticnaKnjigaGetResponseUpisaneGodine
} from "../../../endpoints/student-endpoints/maticna-knjiga/student-maticna-knjiga-get.endpoint";

@Component({
  selector: 'app-student-maticna-knjiga',
  templateUrl: './student-maticna-knjiga.component.html',
  styleUrls: ['./student-maticna-knjiga.component.css']
})
export class StudentMaticnaKnjigaComponent implements OnInit {

  studentid:any;
  public podaci: StudentMaticnaKnjigaGetResponse |null = null;
  constructor(public activatedRoute: ActivatedRoute, private studentMaticnaKnjigaGetEndpoint: StudentMaticnaKnjigaGetEndpoint) { }

  ngOnInit(): void {
    this.studentid = this.activatedRoute.snapshot.params["studentid"];

    this.studentMaticnaKnjigaGetEndpoint.obradi(this.studentid)
      .subscribe({
        next: x=>{
          this.podaci = x;
        }
      })
  }

  ovjera(item: StudentMaticnaKnjigaGetResponseUpisaneGodine) {

  }
}
