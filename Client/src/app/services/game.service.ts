import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { AuthService } from './auth.service';
import { Observable } from 'rxjs';
import { WordModel } from '../models/WordModel';
import { ScoreModel } from '../models/ScoreModel';
import { LifeModel } from '../models/LifeModel';
import { JokerModel } from '../models/jokerModel';

@Injectable({
  providedIn: 'root'
})
export class GameService {

  private getWordUrl: string = environment.apiUrl + environment.gameUrls.getWord
  private gameStatusUrl: string = environment.apiUrl + environment.gameUrls.gameStatus;
  private getScoresUrl: string = environment.apiUrl + environment.gameUrls.getScores
  private changeScoresUrl: string = environment.apiUrl + environment.gameUrls.changeScores;
  private getLifesUrl: string = environment.apiUrl + environment.gameUrls.getLifes;
  private changeLifesUrl: string = environment.apiUrl + environment.gameUrls.changeLifes;
  private getJokersUrl: string = environment.apiUrl + environment.gameUrls.getJockers
  private changeJokersUrl: string = environment.apiUrl + environment.gameUrls.changeJockers;
  private getNextWordUrl: string = environment.apiUrl + environment.gameUrls.getNextWord;
  private newGameUrl: string = environment.apiUrl + environment.gameUrls.newGame;
  private getVictimPictureUrl: string = environment.apiUrl + environment.imageUrls.getVictimPicture;
  private getNextVictimPictureUrl: string = environment.apiUrl + environment.imageUrls.getNextVictimPicture;

  constructor(private http: HttpClient, private authService: AuthService) { }

   getWord(): Observable<WordModel> {
    return this.http.get<WordModel>(this.getWordUrl)
   }
   
   getNextWord(): Observable<WordModel> {
    return this.http.get<WordModel>(this.getNextWordUrl)
   }

   gameStatus(): Observable<any> {
    return this.http.post(this.gameStatusUrl, this.prepareTokenToRequest())
   }

   getScores(): Observable<ScoreModel> {
    return this.http.get<ScoreModel>(this.getScoresUrl)
   }

   changeScores(): Observable<ScoreModel> {
    return this.http.get<ScoreModel>(this.changeScoresUrl)
   } 

   getLifes(): Observable<LifeModel> {
    return this.http.get<LifeModel>(this.getLifesUrl)
   }

   changeLifes(): Observable<LifeModel> {
    return this.http.get<LifeModel>(this.changeLifesUrl)
   }

   getJocker(): Observable<JokerModel> {
    return this.http.get<JokerModel>(this.getJokersUrl)
   }

   changeJocker(): Observable<JokerModel> {
     return this.http.get<JokerModel>(this.changeJokersUrl)
   }

  prepareTokenToRequest(): any {
   return { "token": this.authService.getToken()};
  }

  newGame(): Observable<boolean> {
    return this.http.post<boolean>(this.newGameUrl, this.prepareTokenToRequest());
  }

  Lose(): void {
   
  }

  getVictimPicture(): Observable<any> {
    return this.http.get<any>(this.getVictimPictureUrl)
   }

   getNextVictimPicture(): Observable<any> {
    return this.http.get<any>(this.getNextVictimPictureUrl)
   }
}
