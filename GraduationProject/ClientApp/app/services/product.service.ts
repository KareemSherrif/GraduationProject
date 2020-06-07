import { SearchElements } from './../models/product';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserProduct } from '../models/user-product';

@Injectable({
  providedIn: 'root'
})

export class ProductService {

    constructor(private http: HttpClient) { }

    GetNames(name: string) {
        return this.http.get<SearchElements[]>("/api/Product/GetProduct?name" + name);
    }

    GetAllProducts() {
        return this.http.get<UserProduct[]>("api/product/GetAllProducts");
    }

    GetProductDetails(id: number) {
        return this.http.get("api/product/GetProductDetails/" + id);
    }



}
