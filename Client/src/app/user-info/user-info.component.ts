import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/user.service';
import { tap } from 'rxjs/operators';
import { HttpResponse } from '@angular/common/http';

@Component({
  selector: 'user-info',
  templateUrl: './user-info.component.html',
  styleUrls: ['./user-info.component.css']
})
export class UserInfoComponent implements OnInit {

  public username: string = "dfvdfv";
  public password: string = "fdvdf";
  public changedSuccess: boolean = false;
  public changedFailure: boolean = false;
  
  constructor(private userService: UserService) { }

  ngOnInit(): void {
  }

  changeUsername(username:string){
     this.userService.changeUsername(username).subscribe((r: HttpResponse<any>) =>
  {
    tap((response:HttpResponse<any>) =>  {
      response.ok ? this.showChangedSuccessMessage() : this.showChangedFailureMessage();
    })
  });
}

  changePassword(password: string){
    this.userService.changePassword(password).subscribe((r: HttpResponse<any>) =>
    {
      tap((response:HttpResponse<any>) =>  {
        response.ok ? this.showChangedSuccessMessage() : this.showChangedFailureMessage();
      })
    });
  }

  showChangedSuccessMessage(): void{
    this.changedSuccess = true;

   setTimeout(() => {
    this.changedSuccess = false;
  }, 300);
  }
  
  showChangedFailureMessage(): void{
    this.changedFailure = true;

   setTimeout(() => {
    this.changedFailure = false;
  }, 300);
  }
}
