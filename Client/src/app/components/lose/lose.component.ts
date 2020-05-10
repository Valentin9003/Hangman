import { Component, OnInit } from '@angular/core';
import { GameService } from 'src/app/services/game.service';
import { LosePictureModel } from 'src/app/models/LosePictureModel';
import { Router } from '@angular/router';
import { ImageService } from 'src/app/services/image.service';

@Component({
  selector: 'app-lose',
  templateUrl: './lose.component.html',
  styleUrls: ['./lose.component.css']
})
export class LoseComponent implements OnInit {

  public losePicture: any;

  constructor(private gameService: GameService, private router: Router, private imageService: ImageService) { }

  ngOnInit(): void {
    this.gameService.Lose().subscribe((data: LosePictureModel) => {
      this.losePicture = this.imageService.getImage(data.losePicture);
    })
  }

  newGame() {
    this.router.navigate(['game']);
  }
}
