import { Injectable } from '@angular/core';
import { Observable, BehaviorSubject } from 'rxjs';
import { HttpClient } from '@angular/common/http'
import { environment } from 'src/environments/environment';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private loginPath = environment.apiUrl + environment.authUrls.login;
  private registerPath = environment.apiUrl + environment.authUrls.register;
  
  private loggedIn = new BehaviorSubject<boolean>(false); 

  get isLoggedIn() {
    return this.loggedIn.asObservable();
  }
  constructor(private http: HttpClient, private router: Router) { }

  login(data: any): Observable<any>{
    this.loggedIn.next(true);
    return this.http.post(this.loginPath, data);
  }

  register(data:any){
    return this.http.post(this.registerPath, data)
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
