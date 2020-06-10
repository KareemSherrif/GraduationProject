import { AddProductComponent } from './components/products/add-product/add-product.component';
import { animate } from '@angular/animations';
import { AuthGuard } from './guards/auth.guard';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './components/user/login/login.component';
import { HomeComponent } from "./components/home/home.component";
import { RegistrationComponent } from './components/user/registration/registration.component';
import { ProfileComponent } from './components/profile/profile.component';
import { ListProductsComponent } from './components/products/list-products/list-products.component';
import { ProductDetailsComponent } from './components/products/product-details/product-details.component';
import { ResetPasswordComponent } from './components/user/reset-password/reset-password.component';
import { EmailSentComponent } from './components/user/email-sent/email-sent.component';

const routes: Routes = [
    { path: '', component: HomeComponent },
    { path: 'Registration', component: RegistrationComponent },
    { path: 'Login', component: LoginComponent },
    { path: 'ResetPassword', component: ResetPasswordComponent },
    { path: 'EmailSent', component: EmailSentComponent },
    { path: 'profile', component: ProfileComponent, canActivate: [AuthGuard] },
    { path: 'profile/:id', component: ProfileComponent },
    { path: 'AddProduct', component: AddProductComponent, canActivate: [AuthGuard] },
    { path: 'ListProduct', component: ListProductsComponent, canActivate: [AuthGuard] },
    { path: 'product/Details/:id', component: ProductDetailsComponent, canActivate: [AuthGuard] }
];

@NgModule({
    imports: [RouterModule.forRoot(routes, { useHash: true })],
    exports: [RouterModule]
})
export class AppRoutingModule { }
