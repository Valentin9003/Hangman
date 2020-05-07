import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ChangePasswordModel } from '../models/ChangePasswordModel';
import { ChangeEmailModel } from '../models/ChangeEmailModel';
import { GetPasswordModel } from '../models/GetPasswordModel';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private changePasswordUrl = environment.apiUrl + environment.userInfoUrls.changePassword;
  private changeUsernameUrl = environment.apiUrl + environment.userInfoUrls.changeEmail;
  private getPasswordUrl = environment.apiUrl + environment.userInfoUrls.getPassword;
  private getEmailUrl = environment.apiUrl + environment.userInfoUrls.getEmail;

  constructor(private http: HttpClient) { }

  changePassword(model: ChangePasswordModel): Observable<any>{
  return this.http.post(this.changePasswordUrl, model);
  }

  changeEmail(model: ChangeEmailModel): Observable<any>{
  return this.http.post<ChangeEmailModel>(this.changeUsernameUrl, model);
  } 

  getPassword(): Observable<any>{
   return this.http.get<any>(this.getPasswordUrl);
  }
  getEmail(): Observable<any>{
    return this.http.get(this.getEmailUrl);
  }
}
