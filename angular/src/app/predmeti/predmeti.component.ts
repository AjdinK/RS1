import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {mojConfig} from "../moj_config";

@Component({
  selector: 'app-predmeti',
  templateUrl: './predmeti.component.html',
  styleUrls: ['./predmeti.component.css']
})
export class PredmetiComponent implements OnInit{
  podaci:any = [];
  filterPredmeti: any = "";
  odabraniPredmet: any;

  constructor(private httpKlijent : HttpClient) {
  }

  ngOnInit(): void {
    this.PreuzmiPodatke();
  }
  PreuzmiPodatke() {
    this.httpKlijent.get(mojConfig.adresaServera + "/Predmet/GetAll?nazivFilter=" + this.filterPredmeti).subscribe(x=>{
      this.podaci = x;
    })
  }
  getPodatke() {
    return this.podaci.filter((x:any) => x.nazivPredmeta.toLowerCase().startsWith(this.filterPredmeti.toLowerCase()));
  }

  Snimi() {
    this.httpKlijent.post(mojConfig.adresaServera + "/Predmet/Snimi",this.odabraniPredmet).subscribe(x => {
      this.PreuzmiPodatke();
      this.NoviPredmet();
    });
  }

  NoviPredmet() {
    this.odabraniPredmet = {
      id:0,
      nazivPredmeta: '',
      sifraPredmeta : '',
      ectsBodovi : 0,
      prosjecnaOcjena : 0
    }
  }

}
