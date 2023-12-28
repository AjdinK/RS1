import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {MojConfig} from "../../moj-config";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Injectable} from "@angular/core";
@Injectable({providedIn: 'root'})
export class StudentSnimiEndpoint implements  MyBaseEndpoint<StudentSnimiRequest, number>{
  constructor(public httpClient:HttpClient) { }

  obradi(request: StudentSnimiRequest): Observable<number> {
      let url=MojConfig.adresa_servera+`/student/snimi`;

      return this.httpClient.post<number>(url, request);
    }

}

export interface StudentSnimiRequest {
  id: number;
  ime: string;
  prezime: string;
  opstinaRodjenjaID: number
  slika_base64_format: string | undefined
}

