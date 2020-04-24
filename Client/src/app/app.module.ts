import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { WordComponent } from './word/word.component';
import { VictimPictureComponent } from './victim-picture/victim-picture.component';
import { UserInfoComponent } from './user-info/user-info.component';
import { AlphabetComponent } from './alphabet/alphabet.component';
import { GameComponent } from './game/game.component';
import { GameStatusComponent } from './game.status/game.status.component';
import { NavigationComponent } from './navigation/navigation.component';

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
    NavigationComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
