import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, BehaviorSubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { Joke, JokeResult } from '../models';
@Injectable({
    providedIn: 'root'
}
)
export class JokeService {
    private API_BASE_URL = 'https://api.icndb.com';
    constructor(private http: HttpClient) { }
    public selectedJoke: Joke;

    private messageSource = new BehaviorSubject<Joke>(this.selectedJoke);
    currentJoke = this.messageSource.asObservable();

    getJokes(): Observable<Joke[]> {
        return this.http
            .get<JokeResult>(
            `${this.API_BASE_URL}/jokes/random/5?escape=javascript&limitTo=[nerdy]`
            )
            .pipe(map(result => result.value));
    }
    selectJoke(joke :Joke): void {
        debugger
        this.selectedJoke = joke;
      this.changeMessage(joke);
  }
  changeMessage(newMessage: Joke) {
    this.messageSource.next(newMessage)
  }
}
