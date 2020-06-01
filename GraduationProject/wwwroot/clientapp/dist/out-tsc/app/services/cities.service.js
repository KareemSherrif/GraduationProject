import { __decorate } from "tslib";
import { Injectable } from '@angular/core';
let CitiesService = /** @class */ (() => {
    let CitiesService = class CitiesService {
        constructor(http) {
            this.http = http;
        }
        GetCities() {
            return this.http.get("/api/Cities");
        }
    };
    CitiesService = __decorate([
        Injectable({
            providedIn: 'root'
        })
    ], CitiesService);
    return CitiesService;
})();
export { CitiesService };
//# sourceMappingURL=cities.service.js.map