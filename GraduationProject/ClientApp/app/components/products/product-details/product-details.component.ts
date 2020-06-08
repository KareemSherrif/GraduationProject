import { UserService } from './../../../services/user.service';
import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../../services/product.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {
    id;
    product;
    conditionValue: string;

    constructor(private productService: ProductService, private route: ActivatedRoute, public userservice:UserService) {
        this.id = route.snapshot.paramMap.get('id');
        if (this.id) {
            this.productService.GetProductDetails(this.id)
                .subscribe(data => {
                    this.product = data;
                    console.log(data);
                })
        }
    }
    ShowChat(data) {

        
        document.getElementById("UserName").innerHTML = data.firstName + " " + data.lastName;
        document.getElementById("chat").classList.remove("display-none");
    }

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
  }

}
