import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './Authorize/login/login.component';
import { RegisterComponent } from './Authorize/register/register.component';
import { AuthGuardService } from './Guards/auth-guard.service';
import { TestComponent } from './test/test.component';

const routes: Routes = [
  {path:"",component:RegisterComponent},
  {path:"Login",component:LoginComponent},
  {path:"test",component:TestComponent,canActivate:[AuthGuardService]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
