import {Injectable} from "@angular/core";
import * as signalR from "@microsoft/signalr";
import {MojConfig} from "../moj-config";

@Injectable({providedIn: 'root'})
export class SignalRService{

  otvori_ws_konekciju()
  {
    let connection = new signalR.HubConnectionBuilder()
      .withUrl(`${MojConfig.adresa_servera}/hub-putanja`)
      .build();

    connection.on("prijem_poruke_js", (p)=>{
      debugger
      alert("prijem_poruke_js" + p);
    });

    connection
      .start()
      .then(()=>{
        console.log("konekcija otvorena " + connection.connectionId );
        debugger
      });
  }
}
