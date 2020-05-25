import { TestBed } from '@angular/core/testing';
import { CitiesService } from './cities.service';
describe('CitiesService', () => {
    let service;
    beforeEach(() => {
        TestBed.configureTestingModule({});
        service = TestBed.inject(CitiesService);
    });
    it('should be created', () => {
        expect(service).toBeTruthy();
    });
});
//# sourceMappingURL=cities.service.spec.js.map