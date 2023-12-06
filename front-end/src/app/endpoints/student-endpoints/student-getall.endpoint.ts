import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {MojConfig} from "../../moj-config";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Injectable} from "@angular/core";
@Injectable({providedIn: 'root'})
export class StudentGetAllEndpoint implements  MyBaseEndpoint<void, Student6PretragaResponse>{
  constructor(public httpClient:HttpClient) { }

  obradi(request: void): Observable<Student6PretragaResponse> {
    let url=MojConfig.adresa_servera+`/student/pretraga`;

    let token = window.localStorage.getItem("my-auth-token")??"";

      return this.httpClient.get<Student6PretragaResponse>(url,{
        headers:{
          "my-auth-token": token
        }
      } );
    }

}

export interface Student6PretragaResponse {
  studenti: Student6PretragaResponseStudenti[]
}

export interface Student6PretragaResponseStudenti {
  id: number
  ime: string
  prezime: string
  opstinaRodjenjaNaziv: string
  opstinaRodjenjaDrzava: string
  datumRodjenja: string
  korisnickoIme: string
  slikaKorisnika: string
}
