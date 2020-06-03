import { Component, OnInit } from '@angular/core';
import { UserInfoService } from 'ClientApp/app/services/userInfo.service';
import { Reviews } from 'ClientApp/app/models/reviews';

@Component({
  selector: 'app-reviews',
  templateUrl: './reviews.component.html',
  styleUrls: ['./reviews.component.css']
})
export class ReviewsComponent implements OnInit {
  review: Reviews[] = null;
  constructor(private userInfo:UserInfoService) { }

  ngOnInit(): void {
    this.userInfo.GetUserReviews().subscribe(a => {
      this.review = a;
    });
  }

}
