import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { HttpClient } from '@angular/common/http'
import { Router } from '@angular/router';
import { TokenModel } from '../models/TokenModel';
import { authUrls } from "../common/Urls/authUrls";
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
 
  private loggedIn = new BehaviorSubject<boolean>(false); 
  public username: string;

  get isLoggedIn() {
    return this.loggedIn.asObservable();
  }
  constructor(private http: HttpClient, private router: Router, private toastr: ToastrService ) { }

  login(data: any) {
    this.loggedIn.next(true);
     this.http.post(authUrls.loginPath, data).subscribe((model: TokenModel) =>{
          if(model){
            this.setToken(model.token);
            this.toastr.success("Login successfully");
            this.router.navigate(["game"]);
          }
    })
  }

  getUsername(){
   return this.http.get(authUrls.getUsernamePath);
  }

  register(data:any){
    return this.http.post<TokenModel>(authUrls.registerPath, data);
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
    this.toastr.success("Logout successfully");
    this.router.navigate(["login"]);
  }
}
