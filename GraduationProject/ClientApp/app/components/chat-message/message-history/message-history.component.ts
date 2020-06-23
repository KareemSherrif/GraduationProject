import { ChatService } from './../../../services/chat.service';
import { ChartsService } from './../../../services/charts.service';
import { chatMessage } from './../../../models/chat';
import { UserService } from './../../../services/user.service';
import { newUserMessage } from './../../../models/newUserMessages';
import { Component, OnInit, Input } from '@angular/core';


@Component({
  selector: 'app-message-history',
  templateUrl: './message-history.component.html',
  styleUrls: ['./message-history.component.css']
})
export class MessageHistoryComponent implements OnInit {

 @Input() public chatmessage: chatMessage[] = null;
 @Input() public userInfo: newUserMessage = null;
  constructor(public UserService:UserService, public ChatService:ChatService) { }

  ngOnInit(): void {
    console.log(this.chatmessage);
  }
  SendIt(message) {
  
    this.ChatService.SendMessage(message.value, this.userInfo.userId);
    let newMessage = new chatMessage();
    newMessage.sourceID = this.UserService.CurrentUserId();
    newMessage.sourceName = this.UserService.CurrentUserName();
    newMessage.message = message.value;
    this.chatmessage.push(newMessage);
    message.value = "";
    

  }

}
