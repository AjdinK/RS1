import {Injectable} from "@angular/core";
import * as SignalR from "@microsoft/signalr";

@Injectable({
  providedIn:"root"
})
export  class SignalRProbaService {
  public poruka1 : string = "testSignalR";

  otvoriKanalWebSocket () {
    var connection = new SignalR.HubConnectionBuilder().
      withUrl("/poruke-hub-putanja")
      .build();
    connection.on('slanje_poruke1',(p:string)=>{
      this.poruka1 = p;
    });
    connection.start().then( ()=> {
        console.log("Otvoren kanal WS");
    });

  }
}
