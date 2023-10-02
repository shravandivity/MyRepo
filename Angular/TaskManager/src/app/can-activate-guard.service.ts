import { Injectable } from '@angular/core';
import { LoginService } from './login.service';
import { ActivatedRouteSnapshot, CanActivate, Route, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class CanActivateGuardService implements CanActivate {

  constructor(private loginService:LoginService, private router:Router, private jwtHelperService:JwtHelperService) 
  {

   }
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
    console.log(this.router.url);
    var token = sessionStorage.getItem('currentUser') ? JSON.parse(sessionStorage.getItem('currentUser') as string).token : null;

    if(this.loginService.IsAuthenticated() && this.jwtHelperService.decodeToken(token).role == route.data['expectedRole'])
    {
      return true;
    }
    else
    {
      if(!this.loginService.IsAuthenticated())
      {
        alert('401 UnAuthorized');
      }
      if(this.jwtHelperService.decodeToken(token).role != route.data['expectedRole'])
      {
        alert('Invalid Role.');
      }
      this.router.navigate(["login"]);
      return false;
    }
  }
}
