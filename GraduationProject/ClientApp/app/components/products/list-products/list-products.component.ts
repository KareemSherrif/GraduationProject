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
    conditionValue: string;

    constructor(private productService: ProductService) { }

    checkCondition(value: number) {
        if (value == 0)
            this.conditionValue = 'New'
        if (value == 1)
            this.conditionValue = 'used With Box'
        if (value == 2)
            this.conditionValue = 'used Without Box'
        return this.conditionValue;
    }

    ngOnInit(): void {
        this.productService.GetAllProducts()
            .subscribe(data => {
                this.products = data;
                console.log(data);
            })
  }

}
