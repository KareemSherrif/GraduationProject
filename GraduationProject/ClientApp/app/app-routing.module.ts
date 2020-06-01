import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './components/user/login/login.component';
import { HomeComponent } from "./components/home/home.component";
import { RegistrationComponent } from './components/registration/registration.component';

const routes: Routes = [
    { path: '', component: HomeComponent },
    { path: 'Registration', component: RegistrationComponent },
     {path:'Login',component:LoginComponent}
];

@NgModule({
    imports: [RouterModule.forRoot(routes,{useHash:true})],
    exports: [RouterModule]
})
export class AppRoutingModule { }
