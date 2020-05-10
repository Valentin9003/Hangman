import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';


@Component({
  selector: 'app-word',
  templateUrl: './word.component.html',
  styleUrls: ['./word.component.css']
})
export class WordComponent implements OnInit {

 @Input() public word: string;
 
 @Output() joker: EventEmitter<any> = new EventEmitter();
  constructor() { }

  ngOnInit(): void {
  }

  getJoker(){
    console.log("emit");
  this.joker.emit(null);
  }
}
