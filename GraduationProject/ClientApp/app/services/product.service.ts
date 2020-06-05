import { SearchElements } from './../models/product';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http:HttpClient) { }
  GetNames(name:string) {
    return this.http.get<SearchElements[]>("/api/AddProduct/GetProduct?name" + name);
  }
}
