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
  constructor(public UserService:UserService) { }

  ngOnInit(): void {
    console.log(this.chatmessage);
  }

}
