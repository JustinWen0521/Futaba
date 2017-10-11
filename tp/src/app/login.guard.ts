import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class LoginGuard implements CanActivate {
  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
      if(localStorage.getItem("token") == "-1" || localStorage.getItem("token") == "-2"
      || localStorage.getItem("token") == null || localStorage.getItem("token") == undefined){
        this.router.navigateByUrl('/home');
        return false;
      }else{
        return true;
      }
  }
  constructor(private router : Router){}
}
