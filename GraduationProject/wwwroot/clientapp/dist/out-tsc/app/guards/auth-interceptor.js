import { __decorate } from "tslib";
import { Injectable } from "@angular/core";
import { tap } from 'rxjs/operators';
let AuthInterceptor = /** @class */ (() => {
    let AuthInterceptor = class AuthInterceptor {
        constructor(router, userService) {
            this.router = router;
            this.userService = userService;
        }
        intercept(req, next) {
            const userToken = this.userService.CurrentUserToken();
            if (userToken != null) {
                req = req.clone({
                    setHeaders: {
                        Authorization: "Bearer " + userToken
                    }
                });
                return next.handle(req).pipe(tap(success => { }, err => {
                    if (err.status == 401) {
                        localStorage.removeItem('token');
                        this.router.navigateByUrl('/login');
                    }
                }));
            }
            else {
                return next.handle(req.clone());
            }
        }
    };
    AuthInterceptor = __decorate([
        Injectable()
    ], AuthInterceptor);
    return AuthInterceptor;
})();
export { AuthInterceptor };
//# sourceMappingURL=auth-interceptor.js.map