import { __decorate } from "tslib";
import { Injectable } from '@angular/core';
let UserService = /** @class */ (() => {
    let UserService = class UserService {
        constructor(http, router) {
            this.http = http;
            this.router = router;
        }
        //user Authentication(
        userAuthentication(formData) {
            return this.http.post('api/account/login', formData);
        }
        //check if the user login or not 
        IsLogin() {
            let userToken = localStorage.getItem('token');
            if (userToken != null) {
                return true;
            }
            return false;
        }
        Logout() {
            localStorage.removeItem('token');
            this.router.navigate(['/']);
        }
        CurrentUserToken() {
            return localStorage.getItem('token');
        }
        CurrentUserName() {
            let userToken = localStorage.getItem('token');
            if (!userToken)
                return null;
            let userName = localStorage.getItem('userName');
            return userName;
        }
        CurrentUserId() {
            let userToken = localStorage.getItem('token');
            if (!userToken)
                return null;
            let userId = localStorage.getItem('userId');
            return userId;
        }
    };
    UserService = __decorate([
        Injectable({
            providedIn: 'root'
        })
    ], UserService);
    return UserService;
})();
export { UserService };
//# sourceMappingURL=user.service.js.map