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
  public products: UserProduct[] = [];
  id;
  filterAttribute;
  test_title;
  categoryId: number;
  constructor(private productService: ProductService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.productService.GetAllProducts()
      .subscribe(data => {
        this.products = data;
        console.log(this.products);
      })
      
  }
  filterProductList(data){
    //this.products.filter
    this.products=data;
    console.log(data)
  }
   
  
  // AddToWishList(userProduct:UserProduct) {
  //   this.WishlistService.SetItem(userProduct);
  // }

}
