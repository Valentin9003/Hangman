import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'game-status',
  templateUrl: './game.status.component.html',
  styleUrls: ['./game.status.component.css']
})
export class GameStatusComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
