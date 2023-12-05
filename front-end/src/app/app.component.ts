import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{


  constructor(public router: Router) {
  }

  ngOnInit(): void {
  }


  idi(s: string) {
    this.router.navigate([s])
  }
}
