import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ChangePasswordModel } from '../models/ChangePasswordModel';
import { ChangeEmailModel } from '../models/ChangeEmailModel';
import { GetPasswordModel } from '../models/GetPasswordModel';
import { userUrls } from "../common/userUrls"

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  changePassword(model: ChangePasswordModel): Observable<any>{
  return this.http.post(userUrls .changePasswordUrl, model);
  }

  changeEmail(model: ChangeEmailModel): Observable<any>{
  return this.http.post<ChangeEmailModel>(userUrls.changeUsernameUrl, model);
  } 

  getEmail(): Observable<any>{
    return this.http.get(userUrls.getEmailUrl);
  }
}
