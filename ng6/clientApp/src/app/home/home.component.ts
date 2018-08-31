import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs/operators';

import { User } from '../_models';
import { UserService, MemberService } from '../_services';

import { Member, Filter } from '../models';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';

@Component({ templateUrl: 'home.component.html', styleUrls: ['./home.component.css'] })
export class HomeComponent implements OnInit {
  currentUser: User;
  users: User[] = [];
  members: Member[] = [];
  memberList: Member[] = [];
  selectedMember: Member;
  closeResult: string;;
  filter: Filter = { text: "", isActive: true };
  constructor(private userService: UserService, private memberService: MemberService, private modalService: NgbModal) {
    this.currentUser = JSON.parse(localStorage.getItem('currentUser'));
  }

  ngOnInit() {
    this.loadAllUsers();
    this.getMembers();
    this.memberService.getMembers().pipe(first()).subscribe(members => {
      this.members = members;
      this.filterUpdated();
    });
  }

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
  filterUpdated() {
    // todo replace this with rxjs
    this.memberList = [];
    for (var j = 0; j < this.members.length; j++) {
      if (((this.members[j].firstName != null && this.members[j].lastName != null && (this.members[j].firstName.toLowerCase() + ' ' + this.members[j].lastName.toLowerCase()).includes(this.filter.text.toLowerCase()))
        || this.filter.text === '')
        && (this.members[j].isActive === this.filter.isActive || this.filter.isActive === false))
        this.memberList.push(this.members[j]);

    }
  }
  formatDate(str) {
    if (str == '')
      return str
    return new Date(str).toLocaleDateString();
  }
  open(content, member: Member) {
    this.selectedMember = member;
    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title', size:'lg' }).result.then((result) => {
  
    }, (reason) => {
  
    });
  }
  openCopyPrompt(member) {
    var text = "\t" + member.lastName + "\t" + member.firstName + "\t" + member.address1 + "\t" + member.city + "\t" + member.state + "\t" + member.zip
    window.prompt("Copy for excel", text)
  }
}
