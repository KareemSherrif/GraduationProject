import { __decorate } from "tslib";
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { LoginComponent } from './components/user/login/login.component';
import { HomeComponent } from "./components/home/home.component";
import { RegistrationComponent } from './components/registration/registration.component';
const routes = [
    { path: '', component: HomeComponent },
    { path: 'Registration', component: RegistrationComponent },
    { path: 'Login', component: LoginComponent }
];
let AppRoutingModule = /** @class */ (() => {
    let AppRoutingModule = class AppRoutingModule {
    };
    AppRoutingModule = __decorate([
        NgModule({
            imports: [RouterModule.forRoot(routes, { useHash: true })],
            exports: [RouterModule]
        })
    ], AppRoutingModule);
    return AppRoutingModule;
})();
export { AppRoutingModule };
//# sourceMappingURL=app-routing.module.js.map