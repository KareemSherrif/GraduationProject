import { newUserMessage } from './../../../models/newUserMessages';
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-chat-user-card',
  templateUrl: './chat-user-card.component.html',
  styleUrls: ['./chat-user-card.component.css']
})
export class ChatUserCardComponent implements OnInit {
  @Input() userMessage: newUserMessage = new newUserMessage();
  @Output() OnSelectUser = new EventEmitter();
  constructor() { 
    this.userMessage.name = "Mohamed Amer";
    this.userMessage.userId = "152600";
  }

  ngOnInit(): void {
  }
  ActiveUser(componentActive) {
    let ele: HTMLCollectionOf<Element> = document.getElementsByClassName("chat_list");
   for (let index = 0; index < ele.length; index++) {
     ele[index].classList.remove("active_chat");
   }

    (<HTMLElement>componentActive).classList.add("active_chat");
   
    this.OnSelectUser.emit(this.userMessage);
  }
}
