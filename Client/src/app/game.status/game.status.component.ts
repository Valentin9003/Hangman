import { Component, OnInit } from '@angular/core';
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

  ngOnInit() {
    this.getJokers();
    this.getLifes();
    this.getScores();
  }
  
getJokers(){
this.gameService.getJocker().subscribe(data => {
  this.jokers = data;
})
}

changeJokers(){
  this.gameService.changeJocker().subscribe(data => {
    this.jokers = data;
  })
}

getScores(){
  this.gameService.getScores().subscribe(data => {
    this.scores = data;
  })
}

changeScores(){
  this.gameService.changeScores().subscribe(data => {
    this.scores = data;
  })
}

getLifes(){
  this.gameService.getLifes().subscribe(data => {
    this.lifes = data;
  })
}

changeLifes(){
  this.gameService.changeLifes().subscribe(data => {
    this.lifes = data;
  })
}
}
