import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { AuthService } from './auth.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GameService {

  getWordUrl: string = environment.apiUrl + environment.gameUrls.getWord
  changeWordUrl: string = environment.apiUrl + environment.gameUrls.changeWord;

  constructor(private http: HttpClient, private authService: AuthService) { }

  getWord(): Observable<any> {
   return this.http.post(this.getWordUrl, this.prepareTokenToRequest())
  }

  prepareTokenToRequest(): any {
   return { "token": this.authService.getToken()};
  }
}
