import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Login } from './../Models/login';
import { Register } from '../Models/register';
@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(public http:HttpClient) { }

  login(cred:Login){
   return this.http.post("https://localhost:44399/api/test/login",cred)
  }
  signUp(cred:Register){
    return this.http.post("https://localhost:44399/api/test/Register",cred)
   }

}
