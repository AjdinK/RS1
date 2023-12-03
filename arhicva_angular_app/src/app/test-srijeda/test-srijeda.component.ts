import {Component, Input, OnInit} from '@angular/core';
import {StudentiComponent} from "../studenti/studenti.component";

@Component({
  selector: 'app-test-srijeda',
  templateUrl: './test-srijeda.component.html',
  styleUrls: ['./test-srijeda.component.css']
})
export class TestSrijedaComponent implements OnInit {

  constructor() { }

  @Input()
  ime :string = "";

  @Input()
  public nesto? : StudentiComponent | null ;

  ngOnInit(): void {
  }

}
