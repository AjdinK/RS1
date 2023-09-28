import {Component, OnInit} from '@angular/core';
import {mojConfig} from "./moj_config";
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{

  title = 'angular';

  ngOnInit(): void {

  }

}
