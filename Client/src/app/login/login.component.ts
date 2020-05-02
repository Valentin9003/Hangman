import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms'
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router';
import { tap, map } from 'rxjs/operators';
import { TokenModel } from '../models/TokenModel';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

   loginForm: FormGroup;

  constructor(private fb: FormBuilder, private authService: AuthService, private router: Router) {
    
    this.loginForm = this.fb.group({
      'username': ['', Validators.required],
      'password': ['', Validators.required]
    })
  }

  ngOnInit(): void {
  }
login(){
  this.authService.login(this.loginForm.value)
}

get username() {
  return this.loginForm.get('username')
}

get password() {
  return this.loginForm.get('password')
}
}
