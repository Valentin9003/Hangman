import { Injectable } from '@angular/core';
import { AuthService } from './auth.service';
import { Router, CanActivate, ActivatedRoute } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardService implements CanActivate {

  constructor(private authService: AuthService, private router: Router, private route:ActivatedRoute) {

   }
  canActivate(): boolean {
    this.route.snapshot.url;

    if(this.authService.isAuthenticated()){
      return true;
    }
    else{
      this.router.navigate(["login"]);
    }
  }
}
