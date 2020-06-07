import { ProductService } from './../../../services/product.service';
import { ProductInfo } from './../../../models/productCard';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-userproduct',
  templateUrl: './userproduct.component.html',
  styleUrls: ['./userproduct.component.css']
})
export class UserproductComponent implements OnInit {
  ProductsInfo: ProductInfo[] = null;
  constructor(public ProductService:ProductService) { }

  ngOnInit(): void {
    this.ProductService.GetUserProduct().subscribe(a => {
      this.ProductsInfo = a;
      console.log(this.ProductsInfo);
    });
  }


}
