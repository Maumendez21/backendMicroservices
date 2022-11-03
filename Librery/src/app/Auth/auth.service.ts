import { Injectable } from '@angular/core';
import { User } from './User.model';
import { LoginData } from './Login.data.model';
import { Subject } from 'rxjs';
import { Router } from '@angular/router';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  securityChange = new Subject<boolean>();


  baseURL = environment.BASE_URL;

  public showMenu = false;
  private token = "";


  private user!: User | null;
  constructor(private router: Router, private httpClient: HttpClient) {}

  registerUser(usr: User) {
    this.user = {
      email: usr.email,
      userId: Math.round(Math.random() * 10000).toString(),
      name: usr.name,
      lastname: usr.lastname,
      username: usr.username,
      password: usr.password,
      token: ""
    };

    this.showMenu = true;
    // this.securityChange.next(true);
    this.router.navigate(['/']);

    console.log(this.user);
  }

  login(login: LoginData) {
    // this.user = {
    //   email: login.email,
    //   userId: Math.round(Math.random() * 10000).toString(),
    //   name: '',
    //   lastname: '',
    //   username: '',
    //   password: '',
    // };


    this.httpClient.post<any>(`${this.baseURL}Login`, login)
    .subscribe(data => {

      

      if (data.response.ok) {
        this.token = data.token;

        this.user = {
          userId: data.id,
          email: login.email,
          name: data.name,
          lastname: data.name,
          token: data.token,
          password: '',
          username: data.username,
        };

        this.securityChange.next(true);
        this.router.navigateByUrl('/');
      }
      else {
        this.securityChange.next(false);
        this.user = null;
      }
    });

    // this.showMenu = true;
    // this.router.navigate(['/']);
    // this.securityChange.next(true);
    // this.router.navigateByUrl('/');
  }

  public getToken(){
    return this.token;
  }

  logout() {
    
    this.user = null;
    // this.securityChange.next(false);
    // this.router.navigateByUrl('/login');
    this.showMenu = false;
    this.router.navigate(['/login']);
  }

  getUserCurrent() {
    return { ...this.user };
  }

  OnSession():boolean{
    return this.user!=null;
  }
}
