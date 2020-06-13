import { ProductInfo } from './../../../models/productCard';
import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-product-card',
  templateUrl: './product-card.component.html',
  styleUrls: ['./product-card.component.css']
})
export class ProductCardComponent implements OnInit {
  @Input() productInfo: ProductInfo = new ProductInfo();
  @Input() clickable: boolean = false;
  @Input() Link = "";
  
  constructor() { }

  ngOnInit(): void {
   
  }

}
