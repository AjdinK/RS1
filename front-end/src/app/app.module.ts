import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import {FormsModule} from "@angular/forms";
import { Sedmica4Component } from './sedmica4/sedmica4.component';
import { Sedmica5Component } from './sedmica5/sedmica5.component';
import {HttpClientModule} from "@angular/common/http";
import { Sedmica5PretragaJsComponent } from './sedmica5-pretraga-js/sedmica5-pretraga-js.component';
import { Sedmica5PretragaBackendComponent } from './sedmica5-pretraga-backend/sedmica5-pretraga-backend.component';
import { Sedmica6EditComponent } from './sedmica6-edit/sedmica6-edit.component';
import { RouterModule } from '@angular/router';
@NgModule({
  declarations: [
    AppComponent,
    Sedmica4Component,
    Sedmica5Component,
    Sedmica5PretragaJsComponent,
    Sedmica5PretragaBackendComponent,
    Sedmica6EditComponent
  ],
    imports: [
        BrowserModule,
        FormsModule,
      HttpClientModule,
      RouterModule.forRoot([
        {path:'sedmica4', component: Sedmica4Component},
        {path:'sedmica5', component: Sedmica5Component},
        {path:'sedmica5-js', component: Sedmica5PretragaJsComponent},
        {path:'sedmica5-backend', component: Sedmica5PretragaBackendComponent},
        {path:'sedmica6', component: Sedmica6EditComponent},
      ])
    ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
