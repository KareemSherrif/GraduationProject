import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-rating',
  templateUrl: './rating.component.html',
  styleUrls: ['./rating.component.css']
})
export class RatingComponent implements OnInit {

  @Input() ratingNumber = 0.0;
  @Input() IsMod = false;
  constructor() { }

  ngOnInit(): void {
  }
  Genedate()
  {
    let array = [];
    for (let index = 0; index < 5; index++) {
      if (index < this.ratingNumber) {
        array.push("fa fa-star");
      }
      else
      {
        array.push("fa fa-star-o"); 
      }
    }
    return array;
  }

 

}
