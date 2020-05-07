import { Injectable } from '@angular/core';
import { Observable, BehaviorSubject } from 'rxjs';
import { HttpClient, HttpResponse } from '@angular/common/http'
import { environment } from 'src/environments/environment';
import { Router } from '@angular/router';
import { map, tap } from 'rxjs/operators';
import { TokenModel } from '../models/TokenModel';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private loginPath = environment.apiUrl + environment.authUrls.login;
  private registerPath = environment.apiUrl + environment.authUrls.register;
  
  private loggedIn = new BehaviorSubject<boolean>(false); 
  private Token:TokenModel;

  get isLoggedIn() {
    return this.loggedIn.asObservable();
  }
  constructor(private http: HttpClient, private router: Router) { }

  login(data: any) {
    this.loggedIn.next(true);
     this.http.post(this.loginPath, data).subscribe((model: TokenModel) =>{
          if(model){
            this.setToken(model.token);
            this.router.navigate(["game"]);
          }
          else{ 
          location.reload();
          }
    })
  }

  register(data:any){
    return this.http.post<TokenModel>(this.registerPath, data);
  }

  setToken(token: string) {
    localStorage.setItem('token', token);
  }

  getToken(): string {
    return localStorage.getItem('token');
  }

  deleteToken() {
    localStorage.removeItem('token');
  }

  isAuthenticated(): boolean {
    return this.getToken() !== null ? true : false;
  }

  logout(){
    this.deleteToken();
    this.loggedIn.next(false);
    this.router.navigate(["login"]);
  }
}
