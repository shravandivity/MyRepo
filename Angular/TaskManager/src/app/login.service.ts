import { HttpBackend, HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LoginViewModel } from './login-view-model';
import { Observable, map } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';
import { JsonPipe } from '@angular/common';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private httpBackEnd:HttpBackend, private httpClient : HttpClient, private jwtHelperService : JwtHelperService) { }

  currentUserName:string = "";
  jwtToken:string = ""
  //private httpClient:HttpClient | null = null;

  public Login(loginViewModel:LoginViewModel):Observable<any>
  {
    this.httpClient = new HttpClient(this.httpBackEnd);
    return this.httpClient.post<any>("/authenticate",loginViewModel,{responseType:'json'})
    .pipe(map((user:any)=>{
      //alert('Login service' + user.userName);
      //alert('Login token : ' + user.token);
      if(user)
      {
        this.currentUserName = user.userName; 
        this.jwtToken = user.token;
        sessionStorage.setItem('currentUser', JSON.stringify(user));
      }
      return user;
    }));
  }

  public LogOut()
  {
    this.currentUserName = "";
    sessionStorage.removeItem('currentUser');
  }

  public IsAuthenticated():boolean
  {
    var token = sessionStorage.getItem('currentUser') ? JSON.parse(sessionStorage.getItem('currentUser') as string).token : null;
    if(this.jwtHelperService.isTokenExpired())
    {
      return false;
    }
    else
    {
      return true;
    }
  }
}
