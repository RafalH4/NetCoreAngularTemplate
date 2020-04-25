import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormGroup } from '@angular/forms';
import { Observable } from 'rxjs';
import { User } from 'src/app/models/user.model';
import { map } from 'rxjs/operators';
import { CookieService } from 'ngx-cookie-service';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseUrl: string = 'https://localhost:44390/user'
  decodedToken: any
  public currentUser: Observable<User>
  

  constructor(private http: HttpClient,
    private cookieService: CookieService,
    private jwtHelper: JwtHelperService,
    private router: Router) { }

  login(model: FormGroup){
    return this.http.post(this.baseUrl+'/login', model)
      .pipe(
        map((response : any) =>{
          this.cookieService.set('token', response.token);
          this.decodedToken = this.jwtHelper.decodeToken(response.token);
          console.log(this.decodedToken);
          
        })
      )
    
  }

  logout(){
    if(!this.cookieService.get('token')) {
      alert("Nie jesteś zalogowany")
      return 0;
    }
    this.cookieService.delete('token');
    alert("Wylogowano poprawnie")
    this.router.navigate(['']);
  }

  register(model : FormGroup){
    return this.http.post(this.baseUrl+'/register',  model)
  }

 getToken(){
    return this.cookieService.get('token');
  }

  loggedIn() {
    const token = this.cookieService.get('token');
    return !this.jwtHelper.isTokenExpired(token);
  }



}

