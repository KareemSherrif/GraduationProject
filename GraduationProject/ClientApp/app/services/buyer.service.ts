import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class BuyerService {

  constructor(private http:HttpClient) {

  }
  AddBuyer(productId: number) {
    return this.http.post("/api/Buyer/" + productId, null);
  }

  

}
