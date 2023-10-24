import {Injectable} from "@angular/core";
import * as SignalR from "@microsoft/signalr";
import {MojConfig} from "../moj-config";

@Injectable({
  providedIn:"root"
})
export  class SignalRProba1Service {
  public poruka1 : string = "";
  public poruka2:  string = "";

  otvoriKanalWebSocket () {
    var connection = new SignalR.HubConnectionBuilder().
      withUrl(MojConfig.adresa_servera + "/poruke-hub-putanja")
      .build();
    connection.on('slanje_poruke1',(p1:string)=>{
      this.poruka1 = p1;
    });
    connection.on('slanje_poruke2',(p2:string)=>{
      this.poruka2 = p2;
    });
    connection.start().then( ()=> {
        console.log("Otvoren kanal WS");
    });

  }
}
