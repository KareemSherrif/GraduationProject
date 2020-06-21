import { HttpClient } from '@angular/common/http';
import { newUserMessage } from './../models/newUserMessages';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ChatMessageService {
  public ActiveUser: newUserMessage = null;
  constructor(private http:HttpClient) { }

  GetContacts() {
    return this.http.get<newUserMessage[]>("/ChatApplication/GetContacts");
  }

}
