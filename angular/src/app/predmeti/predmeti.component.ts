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

  constructor(private httpKlijent : HttpClient) {
  }

  ngOnInit(): void {
    this.PreuzmiPodatke();
  }
  PreuzmiPodatke() {
    //https://localhost:7174/Predmet/GetAll
    this.httpKlijent.get(mojConfig.adresaServera + "/Predmet/GetAll?nazivFilter=" + this.filterPredmeti).subscribe(x=>{
      this.podaci = x;
    })
  }
}
