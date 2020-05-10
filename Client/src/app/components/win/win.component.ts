import { Component, OnInit } from '@angular/core';
import {GameService} from "../../services/game.service";
import { ImageService } from 'src/app/services/image.service';
import { WinPictureModel } from 'src/app/models/WinPictureModel';
@Component({
  selector: 'app-win',
  templateUrl: './win.component.html',
  styleUrls: ['./win.component.css']
})
export class WinComponent implements OnInit {

  public winPicture: string;

  constructor(private gameService: GameService, private imageService: ImageService) { }

  ngOnInit(): void {
    this.loadWinPicture();
  }
  loadWinPicture(){
    this.gameService.Win().subscribe((data: WinPictureModel) =>{
      this.winPicture = this.imageService.getImage(data.winPicture);
    })
  }
}

