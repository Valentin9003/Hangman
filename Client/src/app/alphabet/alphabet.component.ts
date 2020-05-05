import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'alphabet',
  templateUrl: './alphabet.component.html',
  styleUrls: ['./alphabet.component.css']
})
export class AlphabetComponent implements OnInit {

  @Output() letter  = new EventEmitter<string>();

  alphabet: string[] = ["A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"]

  constructor() { }

  ngOnInit(): void {
  }
  choiceLetter(letter: any){

    let clickedLetter: string = letter.currentTarget.innerText;

    if(clickedLetter){
       this.letter.emit(clickedLetter);
       letter.currentTarget.innerText = '';
   }
  }

}
