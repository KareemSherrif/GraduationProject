import { WishlistService } from './../../../services/wishlist.service';
import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../../services/product.service';
import { UserProduct } from '../../../models/user-product';

@Component({
  selector: 'app-list-products',
  templateUrl: './list-products.component.html',
  styleUrls: ['./list-products.component.css']
})
export class ListProductsComponent implements OnInit {
    products: UserProduct[] = [];

    constructor(private productService: ProductService,public WishlistService:WishlistService) { }

    ngOnInit(): void {
        this.productService.GetAllProducts()
            .subscribe(data => {
                this.products = data;
                console.log(data);
            })
  }
   
  AddToWishList(userProduct:UserProduct) {
    this.WishlistService.SetItem(userProduct);
  }

}
