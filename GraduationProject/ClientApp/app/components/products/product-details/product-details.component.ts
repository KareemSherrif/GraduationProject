import { ToastrService } from 'ngx-toastr';
import { BuyerService } from './../../../services/buyer.service';
import { ChatService } from './../../../services/chat.service';
import { chatMessage } from './../../../models/chat';
import { UserService } from './../../../services/user.service';
import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../../services/product.service';
import { ActivatedRoute } from '@angular/router';
import { UserInfoService } from '../../../services/userInfo.service';
import { HttpErrorResponse } from '@angular/common/http';
declare var $: any;

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {
    id;
    product;
    conditionValue: string;
    rating;
    Acceptance: string;
    soldItem: number;
    userId: string;

    constructor(private productService: ProductService,
        private route: ActivatedRoute,
        public userservice: UserService,
        private chatMessage: ChatService,
        private userInfoService: UserInfoService,
        private BuyerService: BuyerService,
        private ToastrService: ToastrService) {
        this.id = this.route.snapshot.paramMap.get('id');
        if (this.id) {
            this.productService.GetProductDetails(this.id)
                .subscribe(data => {
                    this.product = data;
                    this.userId = data['userId'];
                    console.log(data);
                    this.GetSellerInfo(this.userId);
                });
        }
    }
    ShowChat(data,productId) {
        this.chatMessage.GetData(data.id);
        document.getElementById("UserName").innerHTML = data.firstName + " " + data.lastName;
        (<HTMLInputElement>document.getElementById("userId")).value = data.id;
        document.getElementById("chat").classList.remove("display-none");
        this.BuyerService.AddBuyer(productId).subscribe(a => {
            

        }, (er: HttpErrorResponse)=>{
                console.log(er.message);
        });
        
    }

    checkCondition(value: number) {
        if (value == 0)
            this.conditionValue = 'New'
        if (value == 1)
            this.conditionValue = 'Used With Box'
        if (value == 2)
            this.conditionValue = 'Used Without Box'
        return this.conditionValue;
    }

    checkAcceptance(value) {
        if (value == 'true' ||  value == 1)
            this.Acceptance = 'Yes';
        if (value == 'false' || value == 0)
            this.Acceptance = 'No';
        return this.Acceptance;
    }

    GetSellerInfo(userId) {
        this.userInfoService.GetNumberOfSoldItems(userId)
            .subscribe(data => {
                this.soldItem = data;
            });

        this.userInfoService.GetUserRatingById(userId)
            .subscribe(data => {
                this.rating = data;
            });
    }

    ngOnInit(): void {

    }

    ngAfterViewInit() {
        $(document).ready(function () {
            $('.thumb a').mouseover(function(e) {
                e.preventDefault();
                $('.imgBox img').attr("src", $(this).attr("href"));
            });
        });
    }

}
