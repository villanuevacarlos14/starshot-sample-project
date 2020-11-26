import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError, concatMap } from 'rxjs/operators';
import { AuthService } from '../service/auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private router: Router,private authService: AuthService){

  }

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> | Promise<boolean | UrlTree> | boolean | UrlTree {
    
    
     return this.authService.getAccount.pipe(concatMap((resp)=>{
        if(resp){
       
          return of(true);
        }else{
        
          this.router.navigate(["/login"]);
          return of(false);
        }
      }),
      catchError((err)=>{
      
        this.router.navigate(["/login"]);
        return of(false);
      }));
      
      
  }
  
}
