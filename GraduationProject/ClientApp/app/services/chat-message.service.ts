import { HttpClient } from '@angular/common/http';
import { newUserMessage } from './../models/newUserMessages';
import { Injectable } from '@angular/core';
import { chatMessage } from '../models/chat';

@Injectable({
  providedIn: 'root'
})
export class ChatMessageService {
  public ActiveUser: newUserMessage = null;
  public chatMessage: chatMessage[] = [];
  constructor(private http:HttpClient) { }

  GetContacts() {
    return this.http.get<newUserMessage[]>("/ChatApplication/GetContacts");

  }

  GetData(Id:string) {
    return this.http.get<chatMessage[]>("/api/Chat/ChatApplication/" + Id)
      .toPromise()
      .then(a => this.chatMessage = a as chatMessage[]);
  }

}
