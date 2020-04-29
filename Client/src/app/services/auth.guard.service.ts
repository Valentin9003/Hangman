import { Injectable } from '@angular/core';
import { AuthService } from './auth.service';
import { Router, CanActivate, RouterStateSnapshot } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardService implements CanActivate {

  constructor(private authService: AuthService, private router: Router, private state: RouterStateSnapshot) {

   }
  canActivate(): boolean {
    

    if(this.authService.isAuthenticated()) { 
      return (this.state.url.match("login") || this.state.url.match("register")) ? false : true
    }
    else{
      this.router.navigate(["login"]);
    }
  }
}
