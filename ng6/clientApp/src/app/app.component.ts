import { Component, OnInit } from '@angular/core';
import { Joke } from '../app/models/joke';
import { Member } from '../app/models/member';
import { JokeService, MemberService} from '../app/_services/';


import { FilterPipe } from "../app/filter/filter.pipe"
import { Filter } from './models';
import { first } from 'rxjs/operators';
import { from } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Angular Playground ';
  selectedJoke: Joke;

  constructor(private jokeService: JokeService, private memberService: MemberService) { }

  ngOnInit() {
    this.jokeService.currentJoke.subscribe(joke => this.selectedJoke = joke);
   
  }
  
}
