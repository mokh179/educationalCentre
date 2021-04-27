import { Component, OnInit } from '@angular/core';
import { Login } from './../../Models/login';
import { LoginService } from './../../Auth/login.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private sr:LoginService,private router:Router) { }
 log:Login=new Login('','')
 fl:boolean=false;
  ngOnInit(): void {
  }
  login(){
this.sr.login(this.log).subscribe(a=>{
  const t=(<any>a).token
  localStorage.setItem("JWT",t)
this.router.navigateByUrl("/test")
console.log("done") 
 this.fl=false;
},err=>{this.fl=true;})
  }

  logout(){
    localStorage.removeItem("JWT");
  }
}
