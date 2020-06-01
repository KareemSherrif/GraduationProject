import { __decorate } from "tslib";
import { Component } from '@angular/core';
let NavbarComponent = class NavbarComponent {
    constructor(userService) {
        this.userService = userService;
    }
    ngOnInit() {
    }
    LogOut() {
        this.userService.Logout();
    }
};
NavbarComponent = __decorate([
    Component({
        selector: 'app-navbar',
        templateUrl: './navbar.component.html',
        styleUrls: ['./navbar.component.css']
    })
], NavbarComponent);
export { NavbarComponent };
//# sourceMappingURL=navbar.component.js.map