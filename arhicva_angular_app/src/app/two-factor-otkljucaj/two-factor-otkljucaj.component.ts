import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {MojConfig} from "../moj-config";

@Component({
  selector: 'app-two-factor-otkljucaj',
  templateUrl: './two-factor-otkljucaj.component.html',
  styleUrls: ['./two-factor-otkljucaj.component.css']
})
export class TwoFactorOtkljucajComponent implements OnInit {
  constructor(private httpKlijent: HttpClient, private router: Router) { }
  kode: string = "";

  ngOnInit(): void {
  }

  otkljucaj() {
    //https://localhost:5001/Autentifikacija/Otkljucaj/asdasd
    this.httpKlijent.get(MojConfig.adresa_servera +
      "/Autentifikacija/Otkljucaj/" + this.kode , MojConfig.http_opcije()).subscribe((x:any)=>{
        this.router.navigateByUrl("/studenti");
    });

  }
}
