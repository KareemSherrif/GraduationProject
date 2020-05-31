import { __decorate } from "tslib";
import { Component } from "@angular/core";
let RegistrationComponent = class RegistrationComponent {
    constructor(areaService, citiesServices, register, toastr, router) {
        this.areaService = areaService;
        this.citiesServices = citiesServices;
        this.register = register;
        this.toastr = toastr;
        this.router = router;
        this.passwordConfirmation = false;
    }
    ngOnInit() {
        this.citiesServices.GetCities().subscribe((a) => {
            this.cities = a;
        });
    }
    OnRegistration(data) {
        if (data.valid) {
            console.log(data.value);
            this.register.RegisterUser(data.value).subscribe((a) => {
                this.toastr.success("The Registration has been success");
                this.router.navigate(['/Login']);
            }, (err) => {
                console.log(err);
                this.toastr.error(err.error);
            });
        }
    }
    OComparePasswords(password, confirmPassword) {
        console.log(confirmPassword.value);
        console.log(password.value);
        this.passwordConfirmation = password.value != confirmPassword.value;
        console.log(this.passwordConfirmation);
    }
    OnCityChange(data) {
        if (data.value != 0) {
            this.areaService.GetAreas(data.value).subscribe((a) => {
                this.areas = a;
                console.log(a);
            });
        }
        else {
            this.areas = [];
        }
    }
};
RegistrationComponent = __decorate([
    Component({
        selector: "app-registration",
        templateUrl: "./registration.component.html",
        styleUrls: ["./registration.component.css"],
    })
], RegistrationComponent);
export { RegistrationComponent };
//# sourceMappingURL=registration.component.js.map