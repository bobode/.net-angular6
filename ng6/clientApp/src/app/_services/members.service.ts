import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, BehaviorSubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { Member } from '../models';
@Injectable({
  providedIn: 'root'
}
)
export class MemberService {
 
  constructor(private http: HttpClient) { }


  getMembers(): Observable<Member[]> {
    return this.http
      .post<Member[]>(`https://localhost:44355/api/Members/GetMembers`, {});
    
  }
  
}
