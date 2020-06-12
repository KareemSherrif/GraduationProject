import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Buyer } from '../models/buyer';

@Injectable({
  providedIn: 'root'
})
export class BuyerService {

  constructor(private http:HttpClient) {

  }
  AddBuyer(productId: number) {
    return this.http.post("/api/Buyer/" + productId, null);
  }
  SelectBuyers(productId: number) {
    return this.http.get<Buyer[]>("/api/Buyer/" + productId);
  }
  IsOwnerOfProduct(productId: number) {
    return this.http.get<boolean>("/api/Buyer/IsOwner/" + productId);
  }

  

}
