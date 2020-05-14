import { Component, OnInit } from '@angular/core';
import { UserService } from '../../services/user.service';
import { GetEmailModel } from '../../models/GetEmailModel';
import { FormBuilder, Validators, FormControl, FormGroup } from '@angular/forms';
import { GetPasswordModel } from '../../models/GetPasswordModel';
import { passwordConfirmValidator } from 'src/app/common/validators/passwordConfirmValidator';

@Component({
  selector: 'user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserInfoComponent implements OnInit {

  public email: string;
  passwordForm: FormGroup = new FormGroup({});
  emailForm: FormGroup = new FormGroup({});
  
  constructor(private userService: UserService, private formBuilder: FormBuilder,) 
  {
     this.emailForm = formBuilder.group({
      change_email: new FormControl('',[Validators.required]),
      password_field: new FormControl('',[Validators.required]),
     });

     this.passwordForm = this.formBuilder.group({
      password: new FormControl('',[Validators.required]),
       new_password: new FormControl('',[Validators.required]),
       confirm_new_password:  new FormControl('',[Validators.required])
     },
      {
      validator: passwordConfirmValidator('new_password','confirm_new_password')
      }
     );
  }

  ngOnInit(): void {
    this.getEmail();
  }

  getEmail(){
  this.userService.getEmail().subscribe((data: GetEmailModel) =>{
  this.email = data.email
  })
  }

  get f(){
    return this.passwordForm.controls;
  }

  get e(){
    return this.emailForm.controls

  }

  submit(){
this.userService.changePassword({
   password:  this.passwordForm.controls["password"].value,
   newPassword: this.passwordForm.controls["new_password"].value,}).subscribe(() => {
     this.emailForm.reset();
});
  }

  submitEmail(){
    this.userService.changeEmail({
      email: this.emailForm.value.change_email,
      password: this.emailForm.value.password_field}).subscribe((data) =>{
        this.email = data.email
        this.emailForm.reset();
    })
   
  }
}
