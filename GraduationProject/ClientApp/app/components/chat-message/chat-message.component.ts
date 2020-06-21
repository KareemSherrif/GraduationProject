import { chatMessage } from 'ClientApp/app/models/chat';
import { newUserMessage } from './../../models/newUserMessages';
import { ChatMessageService } from './../../services/chat-message.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-chat-message',
  templateUrl: './chat-message.component.html',
  styleUrls: ['./chat-message.component.css']
})
export class ChatMessageComponent implements OnInit {

 messages:newUserMessage[] = []
  constructor(public chatmessage:ChatMessageService) { }

  ngOnInit(): void {
    this.chatmessage.GetContacts().subscribe(a => {
      this.messages = a;
      console.log(a);
    });
  }

}
