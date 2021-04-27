import { Component, OnInit } from '@angular/core';
import { LoginService } from 'src/app/Auth/login.service';
import { Router } from '@angular/router';
import { Register } from './../../Models/register';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(private sr:LoginService,private router:Router) { }
  reg:Register=new Register('','','','','','');
  fl:boolean=false;
  mes:string='';
  ngOnInit(): void {
  }
  signUp(){
    this.sr.signUp(this.reg).subscribe(a=>{
      const t=(<any>a).token
      localStorage.setItem("JWT",t)
    this.router.navigateByUrl("/test")
    console.log()
     this.fl=false;
    },err=>{
      //this.mes=(<any>err).error
      console.log((<any>err))
      this.fl=true;
    }
   
    )
  }
}
