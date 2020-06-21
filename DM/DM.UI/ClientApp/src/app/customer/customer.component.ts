import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Util } from '../util/util';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './customer.component.html',
})
export class CustomerComponent {
  public http: HttpClient;
  public util: Util;
  public router: Router;
  public customer: Customer = new Customer();
  public customers: Customer[];
  public isGetCust: boolean = false;
  public isPrcCust: boolean = false;
  public isSearchCust: boolean = false;


  constructor(private _http: HttpClient, private _util: Util, private _router: Router) {
    this.http = _http;
    this.util = _util;
    this.router = _router;   
  }

  ngOnInit() {
    //this.util.PageRedirectOnAuth(this.router, this.router.url);
  }

  Getcustomer() {
    let token: string = this.util.GetCookie().token;
    const httpHeader = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Access-Control-Allow-Origin': '*',
        'DMAUTH': escape(token)
      })
    };

    let custId: string = this.customer.customerId;

    this.http.get<Customer>(this.util.baseUrl + 'api/Customer/GetCustomerById' + '/' + custId, httpHeader).subscribe(result => {
      this.customer = result;
      this.isGetCust = true;
    }, error => console.error(error));
  }

  ProcessCustomer() {

    let token: string = this.util.GetCookie().token;
    const httpHeader = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Access-Control-Allow-Origin': '*',
        'DMAUTH': escape(token)
      })
    };

    let cust: any = this.customer;

    this.http.post<Customer>(this.util.baseUrl + 'api/Customer/ProcessCustomer', cust, httpHeader).subscribe(result => {
      this.customer = result;
      this.isPrcCust = true;
    }, error => {
      console.log(error);
    });

  }

  SearchCustomer() {
    let token: string = this.util.GetCookie().token;
    const httpHeader = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Access-Control-Allow-Origin': '*',
        'DMAUTH': escape(token)
      })
    };

    let cust: any = this.customer;

    this.http.post<Customer[]>(this.util.baseUrl + 'api/Customer/SearchCustomer', cust, httpHeader).subscribe(result => {

      this.customers = result;

      this.isSearchCust = true;
    }, error => {
      console.log(error);
    });

  }
}

class Customer {
  customerId: string;
  firstName: string;
  lastName: string;
  phoneNumber: string;
  address: string;
  dateOfBirth: string;
}

