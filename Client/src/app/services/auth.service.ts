import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http'
import { environment } from 'src/environments/environment';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private loginPath = environment.apiUrl + environment.authUrls.login;
  private registerPath = environment.apiUrl + environment.authUrls.register;
  
  constructor(private http: HttpClient, private router: Router) { }

  login(data: any): Observable<any>{
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
   if(this.getToken()){
    return true;
    }
    return false;
  }
  logout(){
    this.deleteToken();
    this.router.navigate(["login"]);
  }
}
