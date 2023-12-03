import {Injectable} from "@angular/core";
import * as SignalR from "@microsoft/signalr";
import {MojConfig} from "../moj-config";

@Injectable({
  providedIn:"root"
})
export  class SignalRProba2Service {
  public imePrezime : string = "";
  connection?:signalR.HubConnection | null;

  otvoriKanalWebSocket () {
    this.connection = new SignalR.HubConnectionBuilder().
      withUrl(MojConfig.adresa_servera + "/poruke-hub-putanja")
      .build();
    this.connection.on('PosaljiPoruku',(p:string)=>{
      this.imePrezime = p;
    });
   this.connection.start().then( ()=> {
        console.log("Otvoren kanal WS");
    });

  }
  PosaljiImePrezime () {
    this.connection?.invoke("ProsljediPoruku",this.imePrezime)
  }
}

