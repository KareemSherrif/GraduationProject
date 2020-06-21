import { newUserMessage } from './../../../models/newUserMessages';
import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-chat-user-card',
  templateUrl: './chat-user-card.component.html',
  styleUrls: ['./chat-user-card.component.css']
})
export class ChatUserCardComponent implements OnInit {
  @Input() userMessage: newUserMessage = new newUserMessage();
  constructor() { 
    this.userMessage.name = "Mohamed Amer";
    this.userMessage.userId = "152600";
  }

  ngOnInit(): void {
  }
  ActiveUser(componentActive) {
    (<HTMLElement>componentActive).classList.add("active_chat");
  }
}
