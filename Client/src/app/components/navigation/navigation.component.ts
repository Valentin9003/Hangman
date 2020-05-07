import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { GameService } from '../../services/game.service';
import { UsernameModel } from 'src/app/models/UsernameModel';

@Component({
  selector: 'navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.css']
})
export class NavigationComponent implements OnInit {

  public username: string;

  constructor(private authService: AuthService, private gameService: GameService) { 
  }

  ngOnInit() {
    this.getUserName();
  }
  
  logout() { 
    this.authService.logout();
  }

  newGame(): void {
   this.gameService.newGame().subscribe((reload: boolean) =>
        reload ? location.reload() : alert("Something went wrong! Try again..")
      );
    }
      
    getUserName(){
      this.authService.getUsername().subscribe((data: UsernameModel) =>{
        this.username = data.username
      })
    }
}
