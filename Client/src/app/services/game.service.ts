import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { AuthService } from './auth.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GameService {

  private getWordUrl: string = environment.apiUrl + environment.gameUrls.getWord
  private gameStatusUrl: string = environment.apiUrl + environment.gameUrls.gameStatus;
  private getScoresUrl: string = environment.apiUrl + environment.gameUrls.getWord
  private changeScoresUrl: string = environment.apiUrl + environment.gameUrls.gameStatus;
  private getLifesUrl: string = environment.apiUrl + environment.gameUrls;
  private changeLifesUrl: string = environment.apiUrl + environment.gameUrls.gameStatus;
  private getJokersUrl: string = environment.apiUrl + environment.gameUrls.getWord
  private changeJokersUrl: string = environment.apiUrl + environment.gameUrls.gameStatus;
  private nextWordUrl: string = environment.apiUrl + environment.gameUrls.nextWord;

  constructor(private http: HttpClient, private authService: AuthService) { }

   getWord(): Observable<any> {
    return this.http.post(this.getWordUrl, this.prepareTokenToRequest())
   }

   nextWord(): Observable<any> {
    return this.http.post(this.nextWordUrl, this.prepareTokenToRequest())
   }

   gameStatus(): Observable<any> {
    return this.http.post(this.gameStatusUrl, this.prepareTokenToRequest())
   }

   getScores(): Observable<any> {
    return this.http.post(this.getScoresUrl, this.prepareTokenToRequest())
   }

   changeScores(): Observable<any> {
    return this.http.post(this.changeScoresUrl, this.prepareTokenToRequest())
   } 

   getLifes(): Observable<any> {
    return this.http.post(this.getLifesUrl, this.prepareTokenToRequest())
   }

   changeLifes(): Observable<any> {
    return this.http.post(this.changeLifesUrl, this.prepareTokenToRequest())
   }

   getJocker(): Observable<any> {
    return this.http.post(this.getJokersUrl, this.prepareTokenToRequest())
   }

   changeJocker(): Observable<any> {
     return this.http.post(this.changeJokersUrl, this.prepareTokenToRequest())
   }

  prepareTokenToRequest(): any {
   return { "token": this.authService.getToken()};
  }
}
