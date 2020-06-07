import { ProductInfo } from './../models/productCard';
import { SearchElements } from './../models/product';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserProduct } from '../models/user-product';
import { AddProduct } from '../models/addProduct';

@Injectable({
  providedIn: 'root'
})

export class ProductService {

  constructor(private http:HttpClient) { }
  GetNames(name:string) {
    return this.http.get<SearchElements[]>("/api/Product/GetProduct/" + name);
  }
  AddProduct(product: AddProduct) {
    return this.http.post<AddProduct>("/api/Product/Add", product);

  }
  GetUserProduct() {
    return this.http.get<ProductInfo[]>("/api/Product/GetUserProduct");
  }
  GetUserProductById(UserId: string) {
    return this.http.get<ProductInfo[]>("/api/Product/GetUserProduct/" + UserId);
  }
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
