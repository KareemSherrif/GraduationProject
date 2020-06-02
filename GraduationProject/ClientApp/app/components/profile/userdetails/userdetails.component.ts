import { UserInfoService } from './../../../services/userInfo.service';
import { userInfo } from './../../../models/userInfo';
import { UserService } from './../../../services/user.service';
import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-userdetails',
  templateUrl: './userdetails.component.html',
  styleUrls: ['./userdetails.component.css']
})
export class UserdetailsComponent implements OnInit {

  userInfo:userInfo = null;
  constructor(private UserInfoService:UserInfoService) { }

  ngOnInit(): void {
    this.UserInfoService.GetUserInformation().subscribe(a => {
      this.userInfo = a;
      console.log(this.userInfo);
      
    });
   
  }

}
