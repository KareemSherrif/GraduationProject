import { __decorate } from "tslib";
import { Injectable } from '@angular/core';
let AreasService = class AreasService {
    constructor(http) {
        this.http = http;
    }
    GetAreas(id) {
        return this.http.get("/api/Areas/?ID=" + id);
    }
};
AreasService = __decorate([
    Injectable({
        providedIn: 'root'
    })
], AreasService);
export { AreasService };
//# sourceMappingURL=areas.service.js.map