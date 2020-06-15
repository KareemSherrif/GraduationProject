import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ChartsService {

  constructor(private http: HttpClient) {
    
  }
  GetPriceStatistics(id: number) {
   
    this.http.get("/api/Chart/" + id);
  }
}
