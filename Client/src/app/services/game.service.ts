import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AuthService } from './auth.service';
import { Observable } from 'rxjs';
import { WordModel } from '../models/WordModel';
import { ScoreModel } from '../models/ScoreModel';
import { LifeModel } from '../models/LifeModel';
import { JokerModel } from '../models/jokerModel';
import { Router } from '@angular/router';
import { LosePictureModel } from '../models/LosePictureModel';
import {apiUrls}  from '../common/apiUrls'
import { WinPictureModel } from '../models/WinPictureModel';

@Injectable({
  providedIn: 'root'
})
export class GameService {

 
  constructor(private http: HttpClient, private authService: AuthService, private router: Router) { }

   getWord(): Observable<WordModel> {
    return this.http.get<WordModel>(apiUrls.getWord)
   }
   
   getNextWord(): Observable<WordModel> {
    return this.http.get<WordModel>(apiUrls.getNextWord)
   }

   gameStatus(): Observable<any> {
    return this.http.post(apiUrls.gameStatus, this.prepareTokenToRequest())
   }

   getScores(): Observable<ScoreModel> {
    return this.http.get<ScoreModel>(apiUrls.getScores)
   }

   changeScores(): Observable<ScoreModel> {
    return this.http.get<ScoreModel>(apiUrls.changeScores)
   } 

   getLifes(): Observable<LifeModel> {
    return this.http.get<LifeModel>(apiUrls.getLifes)
   }

   changeLifes(): Observable<LifeModel> {
    return this.http.get<LifeModel>(apiUrls.changeLifes)
   }

   getJocker(): Observable<JokerModel> {
    return this.http.get<JokerModel>(apiUrls.getJokers)
   }

   changeJocker(): Observable<JokerModel> {
     return this.http.get<JokerModel>(apiUrls.changeJokers)
   }

  prepareTokenToRequest(): any {
   return { "token": this.authService.getToken()};
  }

  newGame(): Observable<boolean> {
    return this.http.post<boolean>(apiUrls.newGame, this.prepareTokenToRequest());
  }

  Lose(): Observable<any> {
    return this.http.get<LosePictureModel>(apiUrls.getLosePicture);
  }

  Win(): Observable<any> {
    return this.http.get<WinPictureModel>(apiUrls.getWinPicture);
  }

  getVictimPicture(): Observable<any> {
    return this.http.get<any>(apiUrls.getVictimPicture)
   }

   getNextVictimPicture(): Observable<any> {
    return this.http.get<any>(apiUrls.getNextVictimPicture)
   }
}
