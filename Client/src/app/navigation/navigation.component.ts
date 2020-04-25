import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.css']
})
export class NavigationComponent implements OnInit {
public isAuthenticated: boolean;
private isAuthenticated$: Observable<boolean>;

  constructor(private authService: AuthService) { 
    this.isAuthenticated$ = this.authService.isLoggedIn; 
  }

  ngOnInit() {
    this.isAuthenticated$.subscribe((next) => this.isAuthenticated = next);
  }
  
  logout() { 
    this.authService.logout();
  }
}
