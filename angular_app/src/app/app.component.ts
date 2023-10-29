import {Component, OnInit} from '@angular/core';
import {MojConfig} from "./moj-config";
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {AutentifikacijaHelper} from "./_helpers/autentifikacija-helper";
import {LoginInformacije} from "./_helpers/login-informacije";
import {SignalRProba1Service} from "./_servisi/signal-r-proba1-service";

declare function porukaSuccess(a: string):any;
declare function porukaError(a: string):any;

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{

  constructor(private httpKlijent: HttpClient, private router: Router , public signalR : SignalRProba1Service) {
    signalR.otvoriKanalWebSocket();
  }

  logoutButton() {

    let token = MojConfig.http_opcije();
    AutentifikacijaHelper.setLoginInfo(null);

    this.httpKlijent.post(MojConfig.adresa_servera + "/Autentifikacija/Logout/", null, token)
      .subscribe((x: any) => {

        porukaSuccess("Logout uspješan");
      });

    this.router.navigateByUrl("/login");
  }

  ngOnInit(): void {
    let isAktiviran = AutentifikacijaHelper.getLoginInfo()
      .autentifikacijaToken?.korisnickiNalog.isAktiviran;
    if (!isAktiviran){
      this.router.navigate(['/user-not-active']);
    }
  }

  loginInfo():LoginInformacije {
    return AutentifikacijaHelper.getLoginInfo();
  }

}
