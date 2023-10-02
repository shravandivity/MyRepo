import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ClientLocation } from './client-location';

@Injectable({
  providedIn: 'root'
})
export class ClientLocationsService {

  constructor(private httpClient:HttpClient) { }

  getClientLocations():Observable<ClientLocation[]>
  {
    return this.httpClient.get<ClientLocation[]>("/api/ClientLocations",{responseType:'json'});
  }
}
