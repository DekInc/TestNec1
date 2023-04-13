import { Component } from '@angular/core';
import { timer } from 'rxjs';
import { ApiCryptoServiceService } from './api-crypto-service.service';
import { ObtenerPreciosApiView } from '../app/Models/ObtenerPreciosApiView'
import { MonedaView } from './Models/MonedaView';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'NCC Test1';
  public divMoneda1: string = "Loading...";
  public divMoneda2: string = "Loading...";
  public divMoneda3: string = "Loading...";
  public divMoneda4: string = "Loading...";
  public divMoneda5: string = "Loading...";
  public divMoneda1Res: string = "";
  public divMoneda2Res: string = "";
  public divMoneda3Res: string = "";
  public divMoneda4Res: string = "";
  public divMoneda5Res: string = "";
  private respApi!: ObtenerPreciosApiView;
  valorAConvertir: number;
  monedaSeleccionada: string = "BTC";
  source = timer(1000, 5000);

  constructor (private apiCryptos: ApiCryptoServiceService){
    
  }
  obtenerPrecios(){
    this.apiCryptos.Obtener('http://localhost:5032/ObtenerPrecios').subscribe((resp: any) => {
      if (resp != null){
        this.respApi = resp;
        if (resp.errorMessage != ''){
          alert(resp.errorMessage);
        } else {
            //console.log(this.respApi);
            this.divMoneda1 = this.respApi.value[0].name + ' (' + this.respApi.value[0].symbol + ') ' + this.respApi.value[0].price + ' usd';
            this.divMoneda2 = this.respApi.value[1].name + ' (' + this.respApi.value[1].symbol + ') ' + this.respApi.value[1].price + ' usd';
            this.divMoneda3 = this.respApi.value[2].name + ' (' + this.respApi.value[2].symbol + ') ' + this.respApi.value[2].price + ' usd';
            this.divMoneda4 = this.respApi.value[3].name + ' (' + this.respApi.value[3].symbol + ') ' + this.respApi.value[3].price + ' usd';
            this.divMoneda5 = this.respApi.value[4].name + ' (' + this.respApi.value[4].symbol + ') ' + this.respApi.value[4].price + ' usd';
          
        }
      }
    },
    (err) => {
      alert(err);
    });
  }

  valorAChange(event: any) {
    this.valorAConvertir = event.target.value;
  }

  monedaChange(event : any) {
    
    let valorSeleccionado : any = event.target.value;
    this.monedaSeleccionada = valorSeleccionado;
  }

  clickBtnConvertir(){
    var monedaActual : MonedaView | undefined;
    monedaActual = this.respApi.value.find(m => m.symbol == this.monedaSeleccionada);
    if (monedaActual != undefined){
      var valorEnUsd : number;
      valorEnUsd = this.valorAConvertir * monedaActual.price;
      console.log(valorEnUsd);
      this.divMoneda1Res = 'Bitcoins: ' + (valorEnUsd / this.respApi.value[0].price);
      this.divMoneda2Res = 'Binance: ' + (valorEnUsd / this.respApi.value[1].price);
      this.divMoneda3Res = 'Cardano: ' + (valorEnUsd / this.respApi.value[2].price);
      this.divMoneda4Res = 'Ethereum: ' + (valorEnUsd / this.respApi.value[3].price);
      this.divMoneda5Res = 'Tether: ' + (valorEnUsd / this.respApi.value[4].price);
    } else console.log(this.monedaSeleccionada);
  }

  subscribe = this.source.subscribe(val => this.obtenerPrecios() );
}
