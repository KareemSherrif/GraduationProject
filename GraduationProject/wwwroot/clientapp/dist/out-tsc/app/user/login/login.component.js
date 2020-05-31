import { __decorate } from "tslib";
import { Component } from '@angular/core';
let LoginComponent = /** @class */ (() => {
    let LoginComponent = class LoginComponent {
        constructor(userService, router, route) {
            this.userService = userService;
            this.router = router;
            this.route = route;
            this.notLogin = false;
        }
        Save(formData) {
            this.userService.userAuthentication(formData.value).subscribe((data) => {
                console.log('Login Data ', data);
                localStorage.setItem('token', data.token);
                localStorage.setItem('userId', data.userId);
                localStorage.setItem('userName', data.userName);
                //localStorage.setItem('userRole', data.Role);
                let returnUrl = this.route.snapshot.queryParamMap.get('returnUrl');
                this.router.navigate([returnUrl || '/']);
            }, (err) => {
                this.notLogin = true;
            });
        }
        ngOnInit() {
        }
    };
    LoginComponent = __decorate([
        Component({
            selector: 'app-login',
            templateUrl: './login.component.html',
            styleUrls: ['./login.component.css']
        })
    ], LoginComponent);
    return LoginComponent;
})();
export { LoginComponent };
//# sourceMappingURL=login.component.js.map