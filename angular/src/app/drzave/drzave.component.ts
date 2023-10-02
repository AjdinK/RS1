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
  constructor(private httpKlijent : HttpClient) {
  }

  ngOnInit(): void {
    this.httpKlijent.get(mojConfig.adresaServera + "/Drzava/GetAll?nazivFilter=" + this.filterDrzava).subscribe(x=>{
      this.podaci = x;
    })
  }

  getPodatke() {
    if (this.podaci == null)
      return [];

    return this.podaci.filter((x:any) => x.nazivDrzave.toLowerCase().startsWith(this.filterDrzava.toLowerCase()));
  }
}
