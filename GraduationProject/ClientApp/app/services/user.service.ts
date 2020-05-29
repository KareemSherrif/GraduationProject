import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class UserService {

    constructor(private http: HttpClient, private router: Router) { }

    //user Authentication(
    userAuthentication(formData) {
        return this.http.post('api/account/login', formData);
    }

    //check if the user login or not 
    IsLogin() {
        let userToken = localStorage.getItem('token');
        if (userToken != null) {
            return true;
        }
        return false;
    }

    Logout() {
        localStorage.removeItem('token');
        this.router.navigate(['/']);
    }

    CurrentUserToken() {
        return localStorage.getItem('token');
    }

    CurrentUserName() {
        let userToken = localStorage.getItem('token');
        if (!userToken) return null;
        let userName = localStorage.getItem('userName');
        return userName;
    }

    CurrentUserId() {
        let userToken = localStorage.getItem('token');
        if (!userToken) return null;
        let userId = localStorage.getItem('userId');
        return userId;
    }
}
