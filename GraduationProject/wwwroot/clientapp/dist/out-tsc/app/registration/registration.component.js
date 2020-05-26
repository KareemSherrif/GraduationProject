import { __decorate } from "tslib";
import { Component } from '@angular/core';
let RegistrationComponent = class RegistrationComponent {
    constructor(areaService, citiesServices) {
        this.areaService = areaService;
        this.citiesServices = citiesServices;
        this.passwordConfirmation = false;
    }
    ngOnInit() {
        this.citiesServices.GetCities().subscribe(a => {
            this.cities = a;
        });
    }
    OnRegistration(data) {
        console.log(data);
    }
    OComparePasswords(password, confirmPassword) {
        console.log(confirmPassword.value);
        console.log(password.value);
        this.passwordConfirmation = password.value != confirmPassword.value;
        console.log(this.passwordConfirmation);
    }
    OnCityChange(data) {
        if (data.value != 0) {
            this.areaService.GetAreas(data.value).subscribe(a => {
                this.areas = a;
            });
        }
        else {
            this.areas = [];
        }
    }
};
RegistrationComponent = __decorate([
    Component({
        selector: 'app-registration',
        templateUrl: './registration.component.html',
        styleUrls: ['./registration.component.css']
    })
], RegistrationComponent);
export { RegistrationComponent };
//# sourceMappingURL=registration.component.js.map