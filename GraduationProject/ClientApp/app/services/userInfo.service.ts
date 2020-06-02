import { UserService } from './user.service';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders} from '@angular/common/http';
import { Router } from '@angular/router';
import { Login } from '../models/login';
import { userInfo } from '../models/userInfo';


@Injectable({
  providedIn: 'root'
})
export class UserInfoService {
    
    constructor(private http: HttpClient, private UserService: UserService) { }
   
    GetUserInformation() {
        return this.http.get<userInfo>("/api/Account/UserInfo");
    }
    
   
  
}
