import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardService implements CanActivate{

  constructor(private router:Router,private  jwthelper:JwtHelperService) { }

  canActivate(){

    const token=localStorage.getItem("JWT")
    if(token&&!this.jwthelper.isTokenExpired(token))
      return true
    this.router.navigateByUrl("/")
    return false;

  }
}
