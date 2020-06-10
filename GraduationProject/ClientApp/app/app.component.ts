import { ChatService } from './services/chat.service';
import { UserService } from './services/user.service';
import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { animation } from '@angular/animations';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
 
})
export class AppComponent {
  title = 'myapp';
  
  constructor(public UserService:UserService,public ChatService:ChatService) {
    this.ChatService.hubConnection.on("ReciveMessage",  (data)=> {
      alert("Sending Message");
      console.log(data);
      
    });
    
  }

}
