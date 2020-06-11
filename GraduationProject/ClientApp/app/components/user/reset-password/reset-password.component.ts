import { Component, OnInit } from '@angular/core';
import { UserService } from '../../../services/user.service';
import { Router, ActivatedRoute } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.css']
})

export class ResetPasswordComponent implements OnInit {

  constructor(private userService: UserService, private router: Router,
    private route: ActivatedRoute) { }



    check(){
      console.log("checked..")
    }

  OnSubmit(FormData){
    console.log("in function");
    this.userService.SendPasswordResetLink(FormData.value).subscribe((data: any) => {
      console.log('User Data ', data);


    })
  }
  ngOnInit(): void {
  }

}