import { Component, OnInit } from '@angular/core';
import { ProductService } from 'ClientApp/app/services/product.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-filter',
  templateUrl: './filter.component.html',
  styleUrls: ['./filter.component.css']
})
export class FilterComponent implements OnInit {
 id;
 filterAttribute;
 test_title;
 pla;
  constructor(private productService: ProductService,private route:ActivatedRoute) { 
    this.route.params.subscribe(params => {
      this.id = params["id"];
      console.log(this.id);

      this.productService.GetFilters(params["id"]).subscribe(
        (data => {
          this.filterAttribute = data;
          console.log(data);
          this.test_title = data['titleNames'];
          this.pla=this.test_title[0];
          console.log("test title", this.pla);
        }
        ));
        console.log("after function",this.id);
    });
  }

  ngOnInit(): void {
   
  }

}
