import {Injectable} from "@angular/core";
import * as SignalR from "@microsoft/signalr";
import {MojConfig} from "../moj-config";

@Injectable({
  providedIn:"root"
})
export  class SignalRProba2Service {
  public imePrezime : string = "";

  otvoriKanalWebSocket () {
    var connection = new SignalR.HubConnectionBuilder().
      withUrl(MojConfig.adresa_servera + "/poruke-hub-putanja")
      .build();
    connection.on('ime_prezime',(p:string)=>{
      this.imePrezime = p;
    });
    connection.start().then( ()=> {
        console.log("Otvoren kanal WS");
    });

  }
}
