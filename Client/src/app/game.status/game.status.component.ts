import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { GameService } from '../services/game.service';

@Component({
  selector: 'game-status',
  templateUrl: './game.status.component.html',
  styleUrls: ['./game.status.component.css']
})
export class GameStatusComponent implements OnInit {

  public jokers:string;
  public lifes:string;
  public scores:string;
  constructor(private gameService: GameService) { }

  ngOnInit(): void {
  }
getJokers(){
this.gameService.getJocker().subscribe()
}

changeJokers(){
  this.gameService.changeJocker().subscribe()
}

getScores(){
  this.gameService.getScores().subscribe()
}

changeScores(){
  this.gameService.changeScores().subscribe()
}

getLifes(){
  this.gameService.getLifes().subscribe()
}

changeLifes(){
  this.gameService.changeLifes().subscribe()
}
}
