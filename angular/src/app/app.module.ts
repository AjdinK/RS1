import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import {FormsModule} from "@angular/forms";
import {HttpClientModule} from "@angular/common/http";
import { Proba1Component } from './proba1/proba1/proba1.component';
import { StudentComponent } from './student/student.component';
import { PredmetComponent } from './predmet/predmet.component';
import { DrzaveComponent } from './drzave/drzave.component';
import { OpstineComponent } from './opstine/opstine.component';

@NgModule({
  declarations: [
    AppComponent,
    Proba1Component,
    StudentComponent,
    PredmetComponent,
    DrzaveComponent,
    OpstineComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
