import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../../services/auth.service';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
registerForm: FormGroup
  constructor(private fb: FormBuilder, private authService: AuthService, private http: HttpClient, private router: Router) {
    this.registerForm = this.fb.group({
      'username': ["", Validators.required],
      'email': ["", Validators.required],
      'password': ["", Validators.required],
    })
   }

  ngOnInit(): void {
  }

  register(){
    this.authService.register(this.registerForm.value).subscribe(() =>
      this.router.navigate(["login"])
    );

  }
  get username() {
    return this.registerForm.get('username')
  }
  
  get email() {
    return this.registerForm.get('email')
  }
  get password() {
    return this.registerForm.get('password')
  }
  
}
