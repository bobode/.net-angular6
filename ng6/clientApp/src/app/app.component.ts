import { Component, OnInit } from '@angular/core';
import { Joke } from '../app/models/joke';
import { Member } from '../app/models/member';
import { JokeService } from '../app/services/joke.service';
import { MemberService } from '../app/services/members.service';
import { first } from 'rxjs/operators';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Angular Playground ';
  selectedJoke: Joke;
  members: Member[] = [];
  constructor(private jokeService: JokeService, private memberService: MemberService) { }
  
  ngOnInit() {
    this.jokeService.currentJoke.subscribe(joke => this.selectedJoke = joke);
    this.memberService.getMembers().pipe(first()).subscribe(members => {
      this.members = members;
    });
  }
 
}
