import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-word',
  templateUrl: './word.component.html',
  styleUrls: ['./word.component.css']
})
export class WordComponent implements OnInit {

 word: string[] = ['s', 'f','s', 'f','s', 'f','s', 'f','s', 'f','s', 'f','s', 'f','s', 'f','s', 'f','s', 'f'];
ob
  constructor() { }

  ngOnInit(): void {
  }

}
