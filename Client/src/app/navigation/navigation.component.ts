import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { Observable } from 'rxjs';
import { GameService } from '../services/game.service';
import { tap, map } from 'rxjs/operators';

@Component({
  selector: 'navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.css']
})
export class NavigationComponent implements OnInit {


  constructor(private authService: AuthService, private gameService: GameService) { 
  }

  ngOnInit() {
  }
  
  logout() { 
    this.authService.logout();
  }

  newGame(): void {
   this.gameService.newGame().subscribe((reload: boolean) =>
        reload ? location.reload() : alert("Something went wrong! Try again..")
      );
    }
      
}
