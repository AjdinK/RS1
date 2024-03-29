import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { MojConfig } from './moj-config';
import { MyAuthService } from './services/MyAuthService';
import { SignalRService } from './services/signalR.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  constructor(
    public router: Router,
    private httpClient: HttpClient,
    public myAuthService: MyAuthService,
    private signalRService: SignalRService
  ) {}

  ngOnInit(): void {
    this.signalRService.otvori_ws_konekciju();
  }

  idi(s: string) {
    this.router.navigate([s]);
  }

  logout() {
    let token = window.localStorage.getItem('my-auth-token') ?? '';
    window.localStorage.setItem('my-auth-token', '');

    let url = MojConfig.adresa_servera + `/auth/logout`;
    this.httpClient
      .post(
        url,
        {
          signalRConnectionID: SignalRService.ConnectionID,
        },
        {
          headers: {
            'my-auth-token': token,
          },
        }
      )
      .subscribe((x) => {
        console.log('logout uspjesan');
      });
    this.router.navigate(['/auth/login']);
  }
}
