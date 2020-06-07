import { ProductInfo } from './../models/productCard';
import { SearchElements } from './../models/product';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
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
}
