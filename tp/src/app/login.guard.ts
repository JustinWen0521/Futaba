import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class LoginGuard implements CanActivate {
  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
      var mToken = localStorage.getItem("token");
      if(mToken == "-1" || mToken == "-2" || mToken == null || mToken == undefined){
        this.router.navigateByUrl('/Login');
        return false;
      }else{
        return true;
      }
  }
  constructor(private router : Router){}
}
