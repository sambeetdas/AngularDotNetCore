import { Util } from '../util/util';
import { Router, CanActivate } from '@angular/router';
import { Injectable } from '@angular/core';

@Injectable()
export class DmAuthGuard implements CanActivate {

  canActivate(): boolean {
    //debugger;
    if (this._util.IsLoggedin())
      return true;
    else {
      this._router.navigate(['/login']);
      return false;
    }
  }

  constructor(private _router: Router, private _util: Util) {
   
  }

}
