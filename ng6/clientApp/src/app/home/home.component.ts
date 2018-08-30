import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs/operators';

import { User } from '../_models';
import { UserService } from '../_services';

import { Member } from '../models';
import { MemberService } from '../services/members.service';

@Component({ templateUrl: 'home.component.html' })
export class HomeComponent implements OnInit {
  currentUser: User;
  users: User[] = [];
  members: Member[] =[];
  constructor(private userService: UserService, private memberService: MemberService) {
    this.currentUser = JSON.parse(localStorage.getItem('currentUser'));
  }

  ngOnInit() {
    this.loadAllUsers();
    this.getMembers();
  }

  //deleteUser(id: number) {
  //  this.userService.delete(id).pipe(first()).subscribe(() => {
  //    this.loadAllUsers()
  //  });
  //}

  private loadAllUsers() {
    this.userService.getAll().pipe(first()).subscribe(users => {
      this.users = users;
    });
  }
  private getMembers() {
    this.memberService.getMembers().pipe(first()).subscribe(members => {
      this.members = members;
    });
  }
}
