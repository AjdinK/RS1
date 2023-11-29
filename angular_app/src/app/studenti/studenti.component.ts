import { Component, OnInit } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {MojConfig} from "../moj-config";
import {Router} from "@angular/router";
import {SignalRProba2Service} from "../_servisi/signal-r-proba2-service";
import {StudentGetallVM, StudentGetallVMPagedList} from "./student-getall-vm";
declare function porukaSuccess(a: string):any;
declare function porukaError(a: string):any;

@Component({
  selector: 'app-studenti',
  templateUrl: './studenti.component.html',
  styleUrls: ['./studenti.component.css']
})
export class StudentiComponent implements OnInit {
  title:string = 'angularFIT2';

  opstina: string = '';
  studentPodaci?: StudentGetallVMPagedList | null;
  filter_ime_prezime: boolean=false;
  filter_opstina: boolean=false;
  odabranistudent?: StudentGetallVM | null;
  opstinePodaci: any;
  predmetiPodaci:any;
  ime_u_student: string = "";

  currentPage : number = 1;

  constructor(private httpKlijent: HttpClient, private router: Router ,
              public probaSignalR2 : SignalRProba2Service) {
    probaSignalR2.otvoriKanalWebSocket();
  }

  fetchPredmeti():void {
  //https://localhost:5001/Predmet/GetAll
    this.httpKlijent.get(MojConfig.adresa_servera + "/Predmet/GetAll").subscribe((x:any)=>{
      this.predmetiPodaci = x;
    })
  }

  fetchStudenti() :void
  {
    //https://localhost:5001/Student/GetAll?pageNumber=2&pageSize=20
    this.httpKlijent.get<StudentGetallVMPagedList>(MojConfig.adresa_servera+ "/Student/GetAll?pageNumber=" + this.currentPage, MojConfig.http_opcije()).subscribe((x:any)=>{
      this.studentPodaci = x;
    });
  }

  fetchOpstine() :void
  {
    this.httpKlijent.get(MojConfig.adresa_servera+ "/Opstina/GetByAll", MojConfig.http_opcije()).subscribe(x=>{
      this.opstinePodaci = x;
    });
  }

  ngOnInit(): void {
    this.fetchStudenti();
    this.fetchOpstine();
    this.fetchPredmeti();
  }

  get_podaci_filtrirano() {
      if (this.studentPodaci == null)
        return [];

    return this.studentPodaci.dataItems.filter((a:any)=>
      (!this.filter_ime_prezime ||

      (a.ime + " " +a.prezime).startsWith(this.probaSignalR2.imePrezime)

      ||

      (a.prezime + " " +a.ime).startsWith(this.probaSignalR2.imePrezime))

      &&
      (
        !this.filter_opstina ||
        (a.opstina_rodjenja != null && a.opstina_rodjenja.description).startsWith(this.opstina)
      )
    );
  }

  //get_podaci_filtrirano2() {
   // if (this.studentPodaci == null)
    //  return [];

    //return this.studentPodaci.dataItems.filter((a:any)=>(
     // a.ime.toLowerCase().startsWith(this.probaSignalR2.imePrezime)
    //));
//  }

  obrisibutton1(s: any) {
    //kompletan objekat "s" se salje kroz body... post ima 3 parametra
    this.httpKlijent.post(`${MojConfig.adresa_servera}/Student/Obrisi1`, s, MojConfig.http_opcije()).subscribe(x=>{
      this.fetchStudenti();
    });
  }

  obrisibutton2(s: any) {
    //int student id se salje kroz url
    this.httpKlijent.post(`${MojConfig.adresa_servera}/Student/Obrisi2/${s.id}`, MojConfig.http_opcije()).subscribe(x=>{
      this.fetchStudenti();
    });
  }

  novi_student_dugme() {
    this.odabranistudent =   {
      id:0,
      prezime:"",
      ime: this.probaSignalR2.imePrezime,
      opstinaRodjenjaOpis:"",
      brojIndeksa:"",
      createdTime:"",
      drzavaRodjenjaOpis:"",
      opstinaRodjenjaId:5,
      slika_korisnika_nova_base64:"",
      slika_korisnika_postojeca_base64_FS:"",
      slika_korisnika_postojeca_base64_DB:"",
      omiljeniPredmeti: [],
    };
  }

  otvori_maticnuknjigu(s: StudentGetallVM) {
    //
    this.router.navigate(['/student-maticnaknjiga', s.id]);
  }

  snimi_dugme() {
    this.odabranistudent!.omiljeniPredmeti = this.predmetiPodaci.filter((x:any)=> x.jel_selektovan).map((p:any)=>p.id);
    this.httpKlijent.post(`${MojConfig.adresa_servera}/Student/Snimi`, this.odabranistudent, MojConfig.http_opcije()).subscribe(x=>{
      this.fetchStudenti();
      this.odabranistudent=null;
    });
  }

//  randomIntFromInterval(min:number, max:number) { // min and max included
 //   return Math.floor(Math.random() * (max - min + 1) + min)
//  }

 // get_slika_novi_request_FS(s: StudentGetallVM) {
 //    return `${MojConfig.adresa_servera}/Student/GetSlikaFS/${s.id}`;
 // }

 // get_slika_novi_request_DB(s: StudentGetallVM) {
 //   return `${MojConfig.adresa_servera}/Student/GetSlikaDB/${s.id}`;
 // }


  get_slika_base64_FS(s: StudentGetallVM) {
    return "data:image/png;base64,"+ s.slika_korisnika_postojeca_base64_FS;
  }

  get_slika_base64_DB(s: StudentGetallVM) {
    return "data:image/png;base64,"+ s.slika_korisnika_postojeca_base64_DB;
  }

  generisi_preview() {
    // @ts-ignore
    var file = document.getElementById("slika-input").files[0];
    if (file) {
      var reader = new FileReader();
      let this2=this;
      reader.onload = function () {
        this2.odabranistudent!.slika_korisnika_nova_base64 = reader.result?.toString();
      }

      reader.readAsDataURL(file);
    }
  }

  dugmePressMe() {
    let broj = Math.floor(Math.random()*10);
    this.ime_u_student = "Random broj je " + broj ;
  }

  public pageNumbersArray():number[] {
  let rez = [];
  for (let i = 0; i < this.totalPages(); i++){
    rez.push (i + 1);
    }
    return rez;
  }

  private totalPages() {
    if (this.studentPodaci != null)
    return this.studentPodaci?.totalPages;

    return 1;
  }

  goToPage(p: number) {
    this.currentPage = p;
    this.fetchStudenti();
  }

  goToPrev(p:number) {
    if (this.currentPage > 1){
      this.currentPage--;
      this.fetchStudenti();
    }
    if (p == this.currentPage)
      return;
  }
  goToNext(p:number) {
    if (this.currentPage < this.totalPages()){
      this.currentPage++
      this.fetchStudenti();
    }
    if (p == this.currentPage)
      return;
  }

  btnPretrega() {
    this.get_podaci_filtrirano2();
  }
}
