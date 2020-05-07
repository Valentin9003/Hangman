import { Component, OnInit, Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { GameService } from '../services/game.service';
import { tap, map } from 'rxjs/operators';
import { WordModel } from '../models/WordModel';
import { Observable } from 'rxjs';
import { WordService } from '../services/word.service';
import { LifeModel } from '../models/LifeModel';
import { ScoreModel } from '../models/ScoreModel';
import { JokerModel } from '../models/jokerModel';

@Component({
  selector: 'game',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.css']
})
export class GameComponent implements OnInit {

  public word: string = "MNOGODYLGAIGOLQMADUMA";
  public originalWord: string;
  public lifes: number;
  public scores: number;
  public jokers: number;

  constructor(private gameService: GameService, private wordService: WordService) { }

  ngOnInit() {
      this.gameService.getWord().subscribe((model: WordModel) => {
      this.originalWord = model.word.toUpperCase();
      this.word = this.wordService.replaceLetter(model.word.toUpperCase());
    })
  }

   getLetter(letter: string){
     if(this.originalWord.match(letter)){
        this.word = this.wordService.findLetter(this.originalWord, this.word, letter);
        this.checkForNextLevel();
        this.changeScores();
     }
     else{
        this.gameService.changeLifes()
        .subscribe((data: LifeModel) => {
          this.lifes = data.lifes;

          if(data.lose){
            this.reloadGame();
          }
          
       });
     }
  }

  checkForNextLevel(){
    if(!this.word.match('_')){
      this.gameService.getNextWord().subscribe((model: WordModel) =>{
        setTimeout(() => {
      this.word = this.wordService.replaceLetter(model.word);
      this.originalWord = model.word;
      this.reloadGame();
     },1000)
    })
  }}

  reloadGame(){
  location.reload();
  }

  changeScores(){
    this.gameService.changeScores().subscribe((data: ScoreModel) =>{
      this.scores = data.scores
    })
  }

  getJoker(){
    this.gameService.changeJocker().subscribe((data: JokerModel) =>{
      if(data.haveJokers){
        this.jokers = data.jokers;
        this.word = this.wordService.applyJoker(this.originalWord, this.word);
        this.checkForNextLevel();
      }
    })
  }
}
