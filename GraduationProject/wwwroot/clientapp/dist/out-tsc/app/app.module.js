import { __decorate } from "tslib";
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { APP_BASE_HREF } from '@angular/common';
import { AppComponent } from './app.component';
import { LoginComponent } from './user/login/login.component';
import { UserService } from './services/user.service';
import { AuthGuard } from './guards/auth.guard';
import { AuthInterceptor } from './guards/auth-interceptor';
let AppModule = class AppModule {
};
AppModule = __decorate([
    NgModule({
        declarations: [
            AppComponent,
            LoginComponent
        ],
        imports: [
            BrowserModule,
            AppRoutingModule,
            FormsModule,
            HttpClientModule
        ],
        providers: [
            UserService,
            AuthGuard,
            {
                provide: HTTP_INTERCEPTORS,
                useClass: AuthInterceptor,
                multi: true
            },
            { provide: APP_BASE_HREF, useValue: '/' }
        ],
        bootstrap: [AppComponent]
    })
], AppModule);
export { AppModule };
//# sourceMappingURL=app.module.js.map