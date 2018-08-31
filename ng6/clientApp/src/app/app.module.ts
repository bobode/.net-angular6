import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { JokeCardItemComponent } from './jokes/joke-card-item/joke-card-item.component';
import { JokeCardListComponent } from './jokes/joke-card-list/joke-card-list.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FilterPipe } from './filter/filter.pipe';

import { JokesModule , } from './jokes/jokes.module';
import { fakeBackendProvider } from './_helpers';


import {
  MatButtonModule,
  MatCardModule,
  MatIconModule,
  MatProgressBarModule
} from '@angular/material';

import { routing } from './app.routing';

import { JwtInterceptor, ErrorInterceptor } from './_helpers';
import { HomeComponent } from './home';
import { LoginComponent } from './login';


@NgModule({
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    MatCardModule,
    MatProgressBarModule,
    MatButtonModule,
    MatIconModule,
    BrowserAnimationsModule,

    routing
  ],
  declarations: [
    AppComponent,
    HomeComponent,
    LoginComponent,
    JokeCardListComponent,
    JokeCardItemComponent
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },

    // provider used to create fake backend
    fakeBackendProvider
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

