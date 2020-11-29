import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from 'src/app/models/user.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  baseUrl: string = 'https://localhost:5001/User'
  public currentUser: Observable<User>
  
  constructor(private http: HttpClient) { }

  getVeterans() {
    return this.http.get(this.baseUrl + '/GetAllVeterans')
  }
  getVeteran(id) {
    return this.http.get(this.baseUrl + '/GetVeteranById/'+id);
  }

}
