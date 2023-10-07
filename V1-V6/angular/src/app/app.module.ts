import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import {FormsModule} from "@angular/forms";
import {HttpClientModule} from "@angular/common/http";
import { Proba1Component } from './proba1/proba1.component';
import { StudentiComponent } from './studenti/studenti.component';
import { PredmetiComponent } from './predmeti/predmeti.component';
import { DrzaveComponent } from './drzave/drzave.component';
import { OpstineComponent } from './opstine/opstine.component';
import {RouterModule} from "@angular/router";

@NgModule({
  declarations: [
    AppComponent,
    Proba1Component,
    StudentiComponent,
    PredmetiComponent,
    DrzaveComponent,
    OpstineComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot([
      {path: 'studenti',component:StudentiComponent},
      {path: 'predmeti',component:PredmetiComponent},
      {path: 'drzave',component:DrzaveComponent},
      {path: 'opstine',component:OpstineComponent},
      {path: 'proba1',component:Proba1Component},
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
