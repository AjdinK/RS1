import {HttpClient} from "@angular/common/http";
import {Injectable} from "@angular/core";
import {AutentifikacijaToken} from "../../helper/auth/autentifikacijaToken";

@Injectable({providedIn: 'root'})
export class MyAuthService{
  constructor(private httpClient: HttpClient) {
  }
  isLogiran():boolean{
    return this.getAuthorizationToken() != null;
  }

  getAuthorizationToken():AutentifikacijaToken | null {
    let tokenString = window.localStorage.getItem("my-auth-token")??"";
    try {
      return JSON.parse(tokenString);
    }
    catch (e){
      return null;
    }
  }
  isAdmin():boolean {
    return this.getAuthorizationToken()?.korisnickiNalog.isAdmin ?? false
  }
  isNastavnik():boolean{
    return this.getAuthorizationToken()?.korisnickiNalog.isNastavnik ?? false
  }

  isStudentskaSluzba():boolean{
    return this.getAuthorizationToken()?.korisnickiNalog.isStudentskaSluzba ?? false
  }

  isDekan():boolean{
    return this.getAuthorizationToken()?.korisnickiNalog.isDekan ?? false
  }

  isStudent():boolean {
    return this.getAuthorizationToken()?.korisnickiNalog.isStudent ?? false
  }

  isProdekan():boolean{
    return this.getAuthorizationToken()?.korisnickiNalog.isProdekan ?? false
  }
  setLogiraniKorisnik(x: AutentifikacijaToken | null) {

    if (x == null){
      window.localStorage.setItem("my-auth-token", '');
    }
    else {
      window.localStorage.setItem("my-auth-token", JSON.stringify(x));
    }
  }


}
