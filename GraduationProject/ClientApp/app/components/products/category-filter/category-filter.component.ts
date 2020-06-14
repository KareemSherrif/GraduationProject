import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../../services/product.service';
import { category } from 'ClientApp/app/models/Category';
import { UserProduct } from '../../../models/user-product';
//import { Route } from '@angular/compiler/src/core';
import { Router, ActivatedRoute } from '@angular/router';
import { filterAttribute } from 'ClientApp/app/models/filterAttribute';

@Component({
  selector: 'app-category-filter',
  templateUrl: './category-filter.component.html',
  styleUrls: ['./category-filter.component.css']
})
export class CategoryFilterComponent implements OnInit {
  categories: category;
  products: UserProduct[] = [];
  categoryId: number;

  constructor(private productService: ProductService, private route: Router) {
   }
   FilterCategory(categoryId){
    this.route.navigate(['product/ListProduct'])
   }

  ngOnInit(): void {
    this.productService.GetAllCategories().subscribe(data => {
      this.categories=data;
      console.log(data);

      this.productService.GetAllProducts()
      .subscribe(data => {
          this.products = data;
          console.log(data);
      })  
    })
  }

}
