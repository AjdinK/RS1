import {Injectable} from "@angular/core";
import * as SignalR from "@microsoft/signalr";
import {MojConfig} from "../moj-config";

@Injectable({
  providedIn:"root"
})
export  class SignalRProbaService {
  public poruka1 : string = "testSignalR";

  otvoriKanalWebSocket () {
    var connection = new SignalR.HubConnectionBuilder().
      withUrl(MojConfig.adresa_servera + "/poruke-hub-putanja")
      .build();
    connection.on('slanje_poruke',(p:string)=>{
      this.poruka1 = p;
    });
    connection.start().then( ()=> {
        console.log("Otvoren kanal WS");
    });

  }
}
