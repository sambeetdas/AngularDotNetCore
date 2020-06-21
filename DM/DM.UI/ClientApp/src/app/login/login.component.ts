import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { Util, Authenticated } from '../util/util';

@Component({
  selector: 'app-home',
  templateUrl: './login.component.html',
})
export class LoginComponent {

  public user: LoginModel = new LoginModel();
  public jwt: JwtModel = new JwtModel();
  public http: HttpClient;
  public router: Router;  
  public util: Util;
  public auth: Authenticated = new Authenticated();
  public isError: any;
  public errorMsg: any;

  constructor(private _http: HttpClient, private _router: Router, private _util: Util) {
    this.http = _http;
    this.router = _router;
    this.util = _util;
    this.isError = false;
  }

  ngOnInit() {
    this.util.RemoveCookie();
    this.util.RefreshSubjectForNav();
    //this.util.PageRedirectOnAuth(this.router, this.router.url);
  }

  Login() {

    const httpHeader = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Access-Control-Allow-Origin': '*'
      })
    };

    this.http.post(this.util.baseUrl + 'api/user/authenticate', this.user, httpHeader).subscribe(result => {

      this.jwt.Issuer = result['email'];

      this.http.post(this.util.baseUrl + 'api/jwt/createtoken', this.jwt, httpHeader).subscribe(result => {
        //Set Model
        let authModel = this.util.SetModel(this.jwt.Issuer, result["content"]);

        //Set Cookie
        this.util.SetCookie(authModel);

        //Refresh the Nav Menu
        this.util.RefreshSubjectForNav();

        //Redirect to Customer
        this.router.navigate(['/customer']);

      }, error => {
        this.isError = true;
        this.errorMsg = error.message;
      });

    }, error => {
      this.isError = true;
      this.errorMsg = error.message;
    });
  }
}

class LoginModel {
  Email: string;
  Password: string;
}

class JwtModel {
  Issuer: string;
}
