import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { WordComponent } from './components/word/word.component';
import { VictimPictureComponent } from './components/victim-picture/victim-picture.component';
import { UserInfoComponent } from './components/user/user.component';
import { AlphabetComponent } from './components/alphabet/alphabet.component';
import { GameComponent } from './components/game/game.component';
import { GameStatusComponent } from './components/game.status/game.status.component';
import { NavigationComponent } from './components/navigation/navigation.component';
import { TokenInterceptorService } from './services/token-interceptor.service';
import { ErrorInterceptorService } from './services/error-interceptor.service';
import { UnauthorizedNavbarMenuComponent } from './components/unauthorized-navigation/unauthorized-navigation.component';
import { FooterComponent } from './components/footer/footer.component';
import { AboutUsComponent } from './components/about-us/about-us.component';
import { WinComponent } from './components/win/win.component';
import {RouterModule } from '@angular/router';
import { LoseComponent } from './components/lose/lose.component';
import { CommonModule } from '@angular/common';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    WordComponent,
    VictimPictureComponent,
    UserInfoComponent,
    AlphabetComponent,
    GameComponent,
    GameStatusComponent,
    NavigationComponent,
    UnauthorizedNavbarMenuComponent,
    FooterComponent,
    AboutUsComponent,
    WinComponent,
    LoseComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    RouterModule,
    CommonModule
  ],
  providers: [
 {
provide: HTTP_INTERCEPTORS,
useClass: TokenInterceptorService,
multi: true
 },
 {
  provide: HTTP_INTERCEPTORS,
  useClass: ErrorInterceptorService,
  multi: true
 }
],
  bootstrap: [AppComponent]
})
export class AppModule { }
