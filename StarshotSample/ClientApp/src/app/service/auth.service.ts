import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, of } from 'rxjs';
import { concatMap } from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private account = new BehaviorSubject(undefined);
  public getAccount = this.account.asObservable();

  constructor(private httpClient: HttpClient) 
  {
 
    const token = localStorage.getItem("Authorization");

    if(token){
      const userName = localStorage.getItem("UserName");
      this.account.next({
        Token: token,
        Username: userName
      });
    }
    
  }

  public authenticate(request: any){
   
     return this.httpClient.post(`Authentication/authenticate`, request)
      .pipe(concatMap((resp: any)=>{
      
        this.setAccount(resp);
        return of(resp);
      }));
  }

  public logout(){
    localStorage.clear();
    this.setAccount(undefined);

  }

  private setAccount(account: any){
    this.account.next(account);
  }
}
