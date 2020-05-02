import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private changePasswordUrl = environment.apiUrl + environment.userInfoUrls.changePassword;
  private changeUsernameUrl = environment.apiUrl + environment.userInfoUrls.changeUsername;
  private getPasswordUrl = environment.apiUrl + environment.userInfoUrls.getPassword;
  private getUsernameUrl = environment.apiUrl + environment.userInfoUrls.getUsername;

  constructor(private http: HttpClient) { }

  changePassword(password: string): Observable<any>{
  return this.http.post(this.changePasswordUrl,password);
  }

  changeUsername(username: string): Observable<any>{
  return this.http.post(this.changeUsernameUrl,username);
  }

  getUsername(username: string): Observable<any>{
    return this.http.post(this.getUsernameUrl,username);
    }

    getPassword(username: string): Observable<any>{
      return this.http.post(this.getPasswordUrl,username);
      }
}
