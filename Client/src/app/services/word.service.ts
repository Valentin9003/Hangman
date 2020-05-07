import { Injectable } from '@angular/core';


@Injectable({
  providedIn: 'root'
})
export class WordService {

  constructor() { }

  checkLetterExist(letter: string, word: string): boolean{
  
    if(word.match(letter)){
       return true;
    }
       return false;
 }

 replaceLetter(originalWord: string): string{
  let word = originalWord.toUpperCase();
  return word.replace(RegExp('[A-Za-z]','gi'), '_');
 }

 findLetter(originalWord: string, word: string, letter: string): string{
   let letters: string[] = originalWord.split('');
   let result: string[] = word.split('');
   let index: number = 0;

   originalWord.split('')
    .forEach(element => {
      if(element === letter){
         result[index] = letter;
         letters[index] = ""
      }
      index++;
   });

  return result.join('');
  }

  applyJoker(originalWord: string, word: string): string {
    let letter = this.getRandomLetter(originalWord, word)
    let result = this.findLetter(originalWord, word, letter)

  return result;
  }

  private getRandomLetter(originalWord: string, word: string): string {
    let openedLetters = word.split('')
        .filter((value, index, self) => (self.indexOf(value) === index) && value !== '_');
       
     if(openedLetters.length == 0){
       return originalWord[Math.floor(Math.random() * originalWord.length)];
     }

     let unopenedLetters = originalWord.split('').filter((l) => openedLetters.indexOf(l) == -1);

     return unopenedLetters[Math.floor(Math.random() * unopenedLetters.length)];

    
  }
}

