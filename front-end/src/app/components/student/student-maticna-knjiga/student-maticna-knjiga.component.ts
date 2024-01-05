import {Component, OnInit} from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {
  StudentMaticnaKnjigaGetEndpoint, StudentMaticnaKnjigaGetResponse, StudentMaticnaKnjigaGetResponseUpisaneGodine
} from "../../../endpoints/student-endpoints/maticna-knjiga/student-maticna-knjiga-get.endpoint";
import {
  StudentMaticnaKnjigaDodajEndpoint,
  StudentMaticnaKnjigaDodajRequest
} from "../../../endpoints/student-endpoints/maticna-knjiga/student-maticna-knjiga-dodaj.endpoint";
import {
  AkademskeGodineGetEndpoint,
  AkademskeGodineGetResponseAkGodine
} from "../../../endpoints/akademske-godine-endpoints/akademske-godine-get.endpoint";


@Component({
  selector: 'app-student-maticna-knjiga',
  templateUrl: './student-maticna-knjiga.component.html',
  styleUrls: ['./student-maticna-knjiga.component.css']
})
export class StudentMaticnaKnjigaComponent implements OnInit {


  studentid: any;
  podaci: StudentMaticnaKnjigaGetResponse | null = null;
  upisNoviSemestar: StudentMaticnaKnjigaDodajRequest | null = null;
  modalTitle = "";
  akademskeGodinePodaci: AkademskeGodineGetResponseAkGodine[] = [];

  displayedColumns: string[] = ['id', 'akademskaGodina', 'godinaStudija', 'obnova'];

  constructor(
    public activatedRoute: ActivatedRoute,
    private studentMaticnaKnjigaGetEndpoint: StudentMaticnaKnjigaGetEndpoint,
    private akademskeGodineGetEndpoint: AkademskeGodineGetEndpoint,
    private studentMaticnaKnjigaDodajEndpoint: StudentMaticnaKnjigaDodajEndpoint
  ) {
  }

  ngOnInit(): void {
    this.studentid = this.activatedRoute.snapshot.params["studentid"];
    this.fetchMaticnaKnjiga();
    this.fetchAkademskeGodine();
  }

  private fetchAkademskeGodine() {
    this.akademskeGodineGetEndpoint.obradi()
      .subscribe(x => {
        this.akademskeGodinePodaci = x.akademskeGodine
      })
  }

  private fetchMaticnaKnjiga() {
    this.studentMaticnaKnjigaGetEndpoint.obradi(this.studentid)
      .subscribe({
        next: x => {
          this.podaci = x;
          this.modalTitle = x.ime + " " + x.prezime
        }
      })
  }

  ovjera(item: StudentMaticnaKnjigaGetResponseUpisaneGodine) {

  }

  otvoriDialog() {
    this.upisNoviSemestar = {
      cijenaSkolarine: 0,
      obnova: false,
      studentId: this.studentid,
      akademskaGodinaId: 0,
      zimskiSemestarUpis: new Date(),
      godinaStudija: 1
    }
  }

  snimi() {
    if (this.upisNoviSemestar != null) {
      this.studentMaticnaKnjigaDodajEndpoint
        .obradi(this.upisNoviSemestar!)
        .subscribe(x => {
          this.fetchMaticnaKnjiga();
          this.zatvori();

          setTimeout(x=>{
            // @ts-ignore
            dialogSuccess("sve uredu")
          }, 50);
        })
    }
  }

  zatvori() {
    this.upisNoviSemestar = null;
  }

  getDataSource():StudentMaticnaKnjigaGetResponseUpisaneGodine[] {
      return this.podaci?.upisaneGodine??[]
  }
}
