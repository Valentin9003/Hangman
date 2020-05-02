import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { GameService } from '../services/game.service';
import { tap, map } from 'rxjs/operators';
import { WordModel } from '../models/WordModel';
import { Observable } from 'rxjs';

@Component({
  selector: 'game',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.css']
})
export class GameComponent implements OnInit {

  public word: string = "MNOGODYLGAIGOLQMADUMA";

  constructor(private gameService: GameService) { }

  ngOnInit() {
    this.gameService.getWord().subscribe((word: WordModel) => {
      this.word = word.Word; console.log(word)
    })
  }

   getLetter(letter: string){
     
  }
}
