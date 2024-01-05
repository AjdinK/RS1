import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import {FormsModule} from "@angular/forms";
import { Sedmica4Component } from './components/sedmica4/sedmica4.component';
import { Sedmica5Component } from './components/sedmica5/sedmica5.component';
import {HTTP_INTERCEPTORS, HttpClientModule} from "@angular/common/http";
import { Sedmica5PretragaJsComponent } from './components/sedmica5-pretraga-js/sedmica5-pretraga-js.component';
import { Sedmica5PretragaBackendComponent } from './components/sedmica5-pretraga-backend/sedmica5-pretraga-backend.component';
import { Sedmica6EditComponent } from './components/sedmica6-edit/sedmica6-edit.component';
import { RouterModule } from '@angular/router';
import { Sedmica7LoginComponent } from './components/sedmica7-login/sedmica7-login.component';
import {MyAuthInterceptor} from "../helper/auth/my-auth-interceptor.service";
import {AutorizacijaGuard} from "../helper/auth/autorizacija-guard.service";
import { HomeStudentComponent } from './components/home-student/home-student.component';
import { HomeNastavnikComponent } from './components/home-nastavnik/home-nastavnik.component';
import { Authorize2fComponent } from './components/authorize2f/authorize2f.component';
import { StudentMaticnaKnjigaComponent } from './components/student/student-maticna-knjiga/student-maticna-knjiga.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatSlideToggleModule} from "@angular/material/slide-toggle";
import {MatButtonModule} from "@angular/material/button";
import {MatTableModule} from "@angular/material/table";
@NgModule({
  declarations: [
    AppComponent,
    Sedmica4Component,
    Sedmica5Component,
    Sedmica5PretragaJsComponent,
    Sedmica5PretragaBackendComponent,
    Sedmica6EditComponent,
    Sedmica7LoginComponent,
    HomeStudentComponent,
    HomeNastavnikComponent,
    Authorize2fComponent,
    StudentMaticnaKnjigaComponent
  ],
    imports: [
        BrowserModule,
        FormsModule,
        HttpClientModule,
        RouterModule.forRoot([
            {path: '', redirectTo: 'sedmica4', pathMatch: 'full'},
            {path: 'home-student', component: HomeStudentComponent},
            {path: 'home-nastavnik', component: HomeNastavnikComponent},
            {path: 'sedmica4', component: Sedmica4Component},
            {path: 'sedmica5', component: Sedmica5Component},
            {path: 'sedmica5-js', component: Sedmica5PretragaJsComponent, canActivate: [AutorizacijaGuard]},
            {path: 'sedmica5-backend', component: Sedmica5PretragaBackendComponent, canActivate: [AutorizacijaGuard]},
            {path: 'sedmica6', component: Sedmica6EditComponent, canActivate: [AutorizacijaGuard]},
            {path: '2f-authorize', component: Authorize2fComponent, canActivate: [AutorizacijaGuard]},
            {
                path: 'student/maticna-knjiga/:studentid',
                component: StudentMaticnaKnjigaComponent,
                canActivate: [AutorizacijaGuard]
            },
            {path: 'auth/login', component: Sedmica7LoginComponent},
        ]),
        BrowserAnimationsModule,
        MatSlideToggleModule,
        MatButtonModule,
        MatTableModule
    ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: MyAuthInterceptor, multi: true },
    AutorizacijaGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
