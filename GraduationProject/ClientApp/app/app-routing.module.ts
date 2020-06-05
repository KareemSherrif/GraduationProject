import { AddProductComponent } from './components/products/add-product/add-product.component';
import { animate } from '@angular/animations';
import { AuthGuard } from './guards/auth.guard';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './components/user/login/login.component';
import { HomeComponent } from "./components/home/home.component";
import { RegistrationComponent } from './components/user/registration/registration.component';
import { ProfileComponent } from './components/profile/profile.component';

const routes: Routes = [
    { path: '', component: HomeComponent },
    { path: 'Registration', component: RegistrationComponent },
    { path: 'Login', component: LoginComponent},
    { path: 'profile', component: ProfileComponent, canActivate: [AuthGuard] },
    { path: 'profile/:id', component: ProfileComponent },
     {path:'AddProduct',component:AddProductComponent,canActivate:[AuthGuard]}
];

@NgModule({
    imports: [RouterModule.forRoot(routes,{useHash:true})],
    exports: [RouterModule]
})
export class AppRoutingModule { }
