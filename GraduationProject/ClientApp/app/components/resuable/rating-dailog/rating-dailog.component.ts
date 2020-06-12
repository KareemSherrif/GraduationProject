import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-rating-dailog',
  templateUrl: './rating-dailog.component.html',
  styleUrls: ['./rating-dailog.component.css']
})
export class RatingDailogComponent implements OnInit {

  
  constructor(public dialogRef: MatDialogRef<RatingDailogComponent>,
  @Inject(MAT_DIALOG_DATA) public data: any) {

    
  }  

  ngOnInit(): void {
    
  }
  Close() {
    this.dialogRef.close();
  }

}
