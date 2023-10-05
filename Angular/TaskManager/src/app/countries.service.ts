import { Injectable } from '@angular/core';
import { Country } from './country';
import { HttpBackend, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CountriesService {

  constructor(private httpBackEnd:HttpBackend, private httpClient : HttpClient) { }

  getCountries() : Observable<Country[]>
  {
    this.httpClient = new HttpClient(this.httpBackEnd);
    return this.httpClient.get<Country[]>("/api/Countries",{responseType : 'json'});
  }
}
