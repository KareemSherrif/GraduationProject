import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserSettings } from '../models/userSettings';


@Injectable({
  providedIn: 'root'
})
export class UserSettingsService {

  constructor(private http: HttpClient) { 
  }

  ChangeUser(userSettings:UserSettings) {
   return this.http.post<UserSettings>("/api/Profile/Edit/Username",userSettings);
  }

  ChangeEmail(userSettings:UserSettings) {
   return this.http.post<UserSettings>("/api/Profile/Edit/Email",userSettings);
  }

  ChangePassword(userSettings:UserSettings) {
   return this.http.post<UserSettings>("/api/Profile/Edit/Password",userSettings);
  }

  ChangePhone(userSettings:UserSettings) {
   return this.http.post<UserSettings>("/api/Profile/Edit/Phone",userSettings);
  }

  ChangeAddress(userSettings:UserSettings) {
   return this.http.post<UserSettings>("/api/Profile/Edit/Address",userSettings);
  }
}
