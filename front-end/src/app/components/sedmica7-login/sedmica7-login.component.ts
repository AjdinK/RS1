import { Component, OnInit } from '@angular/core';
import {AuthLoginRequest} from "./authLoginRequest";
import {MojConfig} from "../../moj-config";
import {HttpClient} from "@angular/common/http";
import {AuthLoginResponse} from "./authLoginResponse";
import {Router} from "@angular/router";
import {MyAuthService} from "../../services/MyAuthService";

@Component({
  selector: 'app-sedmica7-login',
  templateUrl: './sedmica7-login.component.html',
  styleUrls: ['./sedmica7-login.component.css']
})
export class Sedmica7LoginComponent implements OnInit {

  public loginRequest: AuthLoginRequest = {
    lozinka:"",
    korisnickoIme:""
  };
  constructor(
    public httpClient:HttpClient,
    private router: Router,
    private myAuthService:MyAuthService
  ) { }

  ngOnInit(): void {
  }

  signIn() {
    let url=MojConfig.adresa_servera+`/auth/login`;
    this.httpClient.post<AuthLoginResponse>(url, this.loginRequest).subscribe((x)=>{
      if (!x.isLogiran){
        alert("pogresan username/pass")
      }
      else{
        this.myAuthService.setLogiraniKorisnik(x.autentifikacijaToken);
        if (this.myAuthService.isStudent()){
          this.router.navigate(["/home-student"])
        }
        else{
          this.router.navigate(["/home-nastavnik"])
        }


      }
    })
  }
}
