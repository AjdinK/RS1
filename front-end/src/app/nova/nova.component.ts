import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {MyAuthService} from "../services/MyAuthService";

@Component({
  selector: 'app-nova',
  templateUrl: './nova.component.html',
  styleUrls: ['./nova.component.css']
})
export class NovaComponent implements OnInit {

  constructor(
    private httpKlijent : HttpClient,
    private router : Router,
    private myAuthService: MyAuthService,
  ) { }

  ngOnInit(): void {
  }

}
