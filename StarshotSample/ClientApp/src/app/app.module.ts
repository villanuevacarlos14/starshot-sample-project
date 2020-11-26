import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { LoginComponent } from './login/login.component';
import { EmployeeComponent } from './employee/employee.component';
import { AuthGuard } from './guard/auth.guard';
import { AttendanceComponent } from './attendance/attendance.component';



@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    LoginComponent,
    EmployeeComponent,
    AttendanceComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: 'login', component: LoginComponent, pathMatch: 'full' },
      { path: 'employees', component: EmployeeComponent, canActivate: [AuthGuard] },
      { path: 'attendance', component: AttendanceComponent, canActivate: [AuthGuard] },
      { path: '**', redirectTo: 'attendance'},
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
