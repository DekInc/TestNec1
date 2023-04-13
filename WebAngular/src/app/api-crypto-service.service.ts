import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ApiCryptoServiceService {

  constructor(private http: HttpClient) { 

  }

  public Obtener(urlApi: string){
    return this.http.get(urlApi)
  }
}
