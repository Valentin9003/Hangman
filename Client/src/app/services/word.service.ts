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
  return originalWord.replace(RegExp('[A-Za-z]','gi'), '_');
 }

 findLetter(originalWord: string, word: string, letter: string): string{
   let letters: string[] = originalWord.split('');
   let result: string[] = word.split('');
   let index: number = 0;

   originalWord.split('')
    .forEach(element => {
      if(element === letter){
         result[index] = letter; console.log('index vytre ' + index + element)
         letters[index] = ""
      }
      index++; console.log('index vyn ' + index)
   });
  return result.join('');
  }
}

