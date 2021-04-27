import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './Authorize/login/login.component';

//Configure JWT
import {JwtModule} from '@auth0/angular-jwt';
import { TestComponent } from './test/test.component';
import { RegisterComponent } from './Authorize/register/register.component'

export function tokengetter(){
  return localStorage.getItem("JWT")
}

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    TestComponent,
    RegisterComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,FormsModule,
    JwtModule.forRoot({
      config:{
        tokenGetter:tokengetter,
        allowedDomains:["localhost:44399"],
        disallowedRoutes:[]
      }
    })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
