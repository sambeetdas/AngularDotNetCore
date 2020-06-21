import { Component } from '@angular/core';
import { Util } from '../util/util';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {

  public util: Util;
  public router: Router;
  public authModel: any;

  constructor(private _util: Util, private _router: Router) {
    this.util = _util;
    this.router = _router;
  }

  ngOnInit() {

    this.authModel = this.util.GetCookie();
    this.util.getAuthModel.subscribe(a => this.authModel = a);
  }

  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  logout() {
    this.util.RemoveCookie();
    this.util.RefreshSubjectForNav();
    this.router.navigate(['/login']);
  }
}

