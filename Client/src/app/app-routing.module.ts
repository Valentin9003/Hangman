import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { GameComponent } from './components/game/game.component';
import { AuthGuardService } from './services/auth.guard.service';
import { UserInfoComponent } from './components/user/user.component';
import { UnauthGuardService } from './services/unauth.guard.service';
import { AboutUsComponent } from './components/about-us/about-us.component';
import { LoseComponent } from './components/lose/lose.component';
import { WinComponent } from './components/win/win.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: '/game',
    pathMatch: 'full',
    canActivate:[AuthGuardService]
  },
  {
    path: '',
    redirectTo: '/login',
    pathMatch: 'full',
    canActivate:[UnauthGuardService]
  },
  {
    path: 'game',
    component: GameComponent,
    canActivate:[AuthGuardService]
  },
  {
    path: 'login',
    component: LoginComponent,
    canActivate:[UnauthGuardService]
  },
  {
    path: 'register',
    component: RegisterComponent,
    canActivate:[UnauthGuardService]
  },
  {
    path: 'user',
    component: UserInfoComponent, 
    canActivate:[AuthGuardService]
  },
  {
    path: 'aboutus',
    component: AboutUsComponent
  },
  {
    path: 'lose',
    component: LoseComponent,
    canActivate:[AuthGuardService]
  },
  {
    path: 'win',
    component: WinComponent,
    canActivate:[AuthGuardService]
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
