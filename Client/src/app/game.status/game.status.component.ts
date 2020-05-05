import { Component, OnInit, Input } from '@angular/core';
import { GameService } from '../services/game.service';
import { JokerModel } from '../models/jokerModel';
import { ScoreModel } from '../models/ScoreModel';
import { LifeModel } from '../models/LifeModel';

@Component({
  selector: 'game-status',
  templateUrl: './game.status.component.html',
  styleUrls: ['./game.status.component.css']
})
export class GameStatusComponent implements OnInit {

 @Input() jokers:number;
 @Input() lifes:number;
 @Input() scores:number;
  constructor(private gameService: GameService) { }

  ngOnInit() {
    this.getJokers();
    this.getLifes();
    this.getScores(); console.log(this.lifes + "  Lifes (GameStatus)")
  }
  
getJokers(){
this.gameService.getJocker().subscribe((data: JokerModel) => {
  this.jokers = data.jokers;
})
}

getScores(){
  this.gameService.getScores().subscribe((data: ScoreModel) => {
    this.scores = data.scores;
    console.log(this.scores)
  })
}

getLifes(){
  this.gameService.getLifes().subscribe((data: LifeModel) => {
    this.lifes = data.lifes;
  })
}
}
