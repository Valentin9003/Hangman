import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { GameComponent } from './game/game.component';
import { AuthGuardService } from './services/auth.guard.service';
import { UserInfoComponent } from './user-info/user-info.component';

const routes: Routes = [
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'register',
    component: RegisterComponent
  },
  {
    path: 'game',
    component: GameComponent, 
    //canActivate:[AuthGuardService]
  },
  {
    path: 'user',
    component: UserInfoComponent,
    //canActivate:[AuthGuardService]
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
