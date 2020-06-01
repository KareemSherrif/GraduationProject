import { __decorate } from "tslib";
import { Injectable } from '@angular/core';
let RegistrationService = /** @class */ (() => {
    let RegistrationService = class RegistrationService {
        constructor(http) {
            this.http = http;
        }
        RegisterUser(registerUser) {
            return this.http.post("/api/Account/Register", registerUser);
        }
    };
    RegistrationService = __decorate([
        Injectable({
            providedIn: 'root'
        })
    ], RegistrationService);
    return RegistrationService;
})();
export { RegistrationService };
//# sourceMappingURL=registration.service.js.map