import { __decorate } from "tslib";
import { CitiesService } from './services/cities.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { APP_BASE_HREF } from '@angular/common';
import { AppComponent } from './app.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { RegistrationComponent } from './components/registration/registration.component';
import { HomeComponent } from './components/home/home.component';
import { AreasService } from './services/areas.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatInputModule } from '@angular/material/input';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { LoginComponent } from './components/user/login/login.component';
import { UserService } from './services/user.service';
import { AuthGuard } from './guards/auth.guard';
import { AuthInterceptor } from './guards/auth-interceptor';
import { RouterModule } from '@angular/router';
import { ToastrModule } from 'ngx-toastr';
import { ProfileComponent } from './components/profile/profile.component';
let AppModule = /** @class */ (() => {
    let AppModule = class AppModule {
    };
    AppModule = __decorate([
        NgModule({
            declarations: [
                AppComponent,
                NavbarComponent,
                RegistrationComponent,
                HomeComponent,
                LoginComponent,
                ProfileComponent
            ],
            imports: [
                BrowserModule,
                FormsModule,
                HttpClientModule,
                MatInputModule,
                BrowserAnimationsModule,
                MatCheckboxModule,
                MatDatepickerModule,
                MatNativeDateModule,
                ToastrModule.forRoot(),
                RouterModule,
                AppRoutingModule
            ],
            providers: [
                [AreasService, CitiesService],
                UserService,
                AuthGuard,
                {
                    provide: HTTP_INTERCEPTORS,
                    useClass: AuthInterceptor,
                    multi: true
                },
                { provide: APP_BASE_HREF, useValue: '/' },
            ],
            bootstrap: [AppComponent]
        })
    ], AppModule);
    return AppModule;
})();
export { AppModule };
//# sourceMappingURL=app.module.js.map