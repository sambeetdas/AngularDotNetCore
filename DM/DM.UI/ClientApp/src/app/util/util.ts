import { HttpClientModule } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Subject } from 'rxjs';

//@Injectable({ providedIn: 'root' })
export class Util {

  public auth: Authenticated = new Authenticated();
  public getAuthModel = new Subject();
  public baseUrl: string = "https://localhost:44328/"; 

  constructor() {
  }

  public SetModel(user: string, token: string): Authenticated {
    this.auth.isAuthenticated = true;
    this.auth.user = user;
    this.auth.token = token;

    return this.auth;
  }

  public SetCookie(auth: Authenticated) {
    localStorage.setItem('dm_cookie', JSON.stringify(auth));
  }

  public GetCookie(): Authenticated {
    let authJson: string = localStorage.getItem('dm_cookie');
    let authModel: Authenticated = Object.assign(new Authenticated(), JSON.parse(authJson));
    return authModel;
  }

  public RemoveCookie() {
    localStorage.removeItem('dm_cookie')
  }

  //public PageRedirectOnAuth(router: Router, url: string) {
  //  let authModel = this.GetCookie();
  //  if (!authModel.isAuthenticated) {
  //    router.navigate(['/login']);
  //  }
  //}

  public IsLoggedin() {
    let authModel = this.GetCookie();
    return !!authModel.isAuthenticated;
  }

  public RefreshSubjectForNav() {
    let cookieContent = this.GetCookie();
    this.getAuthModel.next(cookieContent);
  }

}

export class Authenticated {
  token: string;
  user: string;
  isAuthenticated: boolean;
}
