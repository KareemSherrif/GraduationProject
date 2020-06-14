import { WishlistService } from './../../../services/wishlist.service';
import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../../services/product.service';
import { UserProduct } from '../../../models/user-product';
import { ActivatedRoute } from '@angular/router';
import { filterAttribute } from 'ClientApp/app/models/filterAttribute';

@Component({
  selector: 'app-list-products',
  templateUrl: './list-products.component.html',
  styleUrls: ['./list-products.component.css']
})
export class ListProductsComponent implements OnInit {
  products: UserProduct[] = [];
  id;
  filterAttribute;
  test_title;
  constructor(private productService: ProductService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.productService.GetAllProducts()
      .subscribe(data => {
        this.products = data;
        //console.log(data);
      })

  }
   
  AddToWishList(userProduct:UserProduct) {
    this.WishlistService.SetItem(userProduct);
  }

}
