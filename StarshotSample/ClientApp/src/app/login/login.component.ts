import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ValidationErrors, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Observable, of, Subscription } from 'rxjs';
import { AuthService } from '../service/auth.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit, OnDestroy {
  subscriptions: Subscription = new Subscription();
  loginForm: FormGroup = this.fb.group({});
  constructor(private router: Router,private fb: FormBuilder, private authService: AuthService) 
  {
     this.subscriptions.add(this.authService.getAccount.subscribe((resp)=>{
      if(resp){
        this.router.navigate(["/attendance"]);
      }      
    }));

  }
  
  ngOnDestroy(): void {
    this.subscriptions.unsubscribe();
  }

  ngOnInit() {
    this.loginForm = this.fb.group({
      UserName: ['', Validators.required],
      Password: ['',Validators.required]
    });
  }


  login(){
    if(this.loginForm.valid)
    {
      this.authService.authenticate(this.loginForm.getRawValue())
      .subscribe((resp: any)=>{

          localStorage.setItem("Authorization", `bearer ${resp.token}`);
          localStorage.setItem("UserName", resp.userName);
          this.router.navigate(["/attendance"]);
       }, (err)=>{

        this.loginForm.setErrors({incorrect: err.error.message});
      });

    }
  }

  private compare(formGroup: FormGroup) : Observable<ValidationErrors | null>
  {
    var password = formGroup.get('Password');
  
    return of({});
  }

 

}
