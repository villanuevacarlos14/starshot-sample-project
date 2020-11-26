import { Component, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { AuthService } from '../service/auth.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnDestroy {
  isExpanded = false;
  isLoggedIn: boolean = false;
  subsriptions: Subscription = new Subscription();
  constructor(private authService: AuthService, private router: Router){
    this.subsriptions.add(
      this.authService.getAccount.subscribe((data)=>{

        if(!data){
          this.isLoggedIn = false;
          this.router.navigate(["/login"]);
        }else{
          this.isLoggedIn =true;
        }
    }));
  }
  ngOnDestroy(): void {
    this.subsriptions.unsubscribe();
  }
  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
  logout(){
    
    this.authService.logout();
  }
}
