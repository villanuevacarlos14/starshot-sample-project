import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../service/employee.service';
import * as moment from 'moment';
import { FormBuilder, FormGroup } from '@angular/forms';
import { formatDate } from '@angular/common';
import { BehaviorSubject, of } from 'rxjs';
@Component({
  selector: 'app-attendance',
  templateUrl: './attendance.component.html',
  styleUrls: ['./attendance.component.css']
})
export class AttendanceComponent implements OnInit {
  private dateSubject = new BehaviorSubject(moment().toDate());
  dt: Date = moment().toDate();
  isCurrentDate: boolean = false;
  data: any = {
    employees: [],
    timedInEmployees: [],
    timeOutEmployees: []
  };

  constructor(private employeService: EmployeeService, private fb: FormBuilder) 
  {
    this.dateSubject.subscribe((data)=>{
 
      this.employeService.attendance(data).subscribe((resp)=>{
        this.data = resp;
      });
    });
  }

  

  cn(event){

    this.dt = new Date(event);
    this.dateSubject.next(this.dt);
  }
 
  timeIn(employeeId, index){

    this.employeService.timein(employeeId, this.dt).subscribe((data)=>{
      this.data.employees.splice(index,1);
      this.data.timedInEmployees.push(data);
    });
  }
  timeOut(employeeId, index){
  
    this.employeService.timeout(employeeId, this.dt).subscribe((data)=>{
      this.data.timedInEmployees.splice(index,1);
      this.data.timeOutEmployees.push(data);
    });
  }
  ngOnInit() {

 
  }

}
