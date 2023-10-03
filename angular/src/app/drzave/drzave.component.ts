import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {mojConfig} from "../moj_config";

@Component({
  selector: 'app-drzave',
  templateUrl: './drzave.component.html',
  styleUrls: ['./drzave.component.css']
})
export class DrzaveComponent implements OnInit{
  private podaci: any;
  filterDrzava: any = "";
  odabranaDrzava: any;
  constructor(private httpKlijent : HttpClient) {
  }

  ngOnInit(): void {
    this.httpKlijent.get(mojConfig.adresaServera + "/Drzava/GetAll?nazivFilter=" + this.filterDrzava).subscribe(x=>{
      this.podaci = x;
    })
  }

  PreuzmiPodatke() {
    if (this.podaci == null)
      return [];

    return this.podaci.filter((x:any) => x.nazivDrzave.toLowerCase().startsWith(this.filterDrzava.toLowerCase()));
  }

  Snimi() {
    this.httpKlijent.post(mojConfig.adresaServera + "/Drzava/Snimi", this.odabranaDrzava).subscribe(x=>{
      window.alert('Drzava saved successfully');
      this.NovaDrzava();
      this.PreuzmiPodatke();
    })
  }

  NovaDrzava() {
    this.odabranaDrzava = {
      id: 0,
      nazivDrzave:'',
      skracenicaDrzave:''
    }
  }
  //'https://localhost:7174/Drzava/Brisi/id?id=5'
  Brisi(id : number ) {
    this.httpKlijent.delete(mojConfig.adresaServera + '/Drzava/Brisi/id?id=' + id).subscribe(x=>{
      this.PreuzmiPodatke();
      this.NovaDrzava();
    })
  }
}
