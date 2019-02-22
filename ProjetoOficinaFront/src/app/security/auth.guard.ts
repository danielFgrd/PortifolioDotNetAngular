import { CanActivate, Router, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree } from '@angular/router';
import { SharedService } from '../services/shared.service';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';

@Injectable()
export class AuthGuard implements CanActivate{
    

    shared: SharedService;

    constructor(
        private router: Router
    ){
        this.shared = SharedService.getInstance();
    }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | Observable<boolean> {
        
        if(this.shared.isLoggedIn()){
            return true
        }else{
            this.router.navigate(['login']);
        }   
        throw new Error("Method not implemented.");
    }

}