import { ViewChild } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { debounceTime } from 'rxjs/operators';
import { EmployeeService } from '../service/employee.service';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {
  @ViewChild('closebutton',{static: false}) closebutton;
 
  index: number;
  employees: any[] = [];
  addEmployeeForm: FormGroup = this.fb.group({});
  editEmployeeForm: FormGroup = this.fb.group({});
  filterEmployeeGroup: FormGroup = this.fb.group({});
  constructor(private fb: FormBuilder, private employeeService: EmployeeService) { }
  saving: boolean = false;
  loading: boolean = false;
  ngOnInit() {
    this.loading = true;
    this.employeeService.get().subscribe((resp : any[])=>{
      this.employees = resp;
      this.loading = false;
    });

    this.addEmployeeForm = this.fb.group({
      Name: ['',Validators.required],
      Active: [false]
    });

    this.editEmployeeForm = this.fb.group({
      Id: [null, Validators.required],
      Name: ['',Validators.required],
      Active: [false]
    });

    this.filterEmployeeGroup = this.fb.group({
      search: [''],
      activeFilter: [0]
    });

    this.filterEmployeeGroup.get('search').valueChanges.pipe(debounceTime(500)).subscribe((data)=>{
      this.loading = true;
      this.employeeService.get(data,this.filterEmployeeGroup.get('activeFilter').value).subscribe((resp : any[])=>{
        this.employees = resp;
        this.loading = false;
      });
    });
    this.filterEmployeeGroup.get('activeFilter').valueChanges.pipe(debounceTime(500)).subscribe((data)=>{
      this.loading = true;
      this.employeeService.get(this.filterEmployeeGroup.get('search').value,data).subscribe((resp : any[])=>{
        this.employees = resp;
        this.loading = false;
      });
    });
  }
  
  modify(emp: any, i: number){
    this.editEmployeeForm = this.fb.group({
      Id: [emp.id, Validators.required],
      Name: [emp.name,Validators.required],
      Active: [emp.active]
    });
    this.index = i;
  }

  delete(){
      this.saving = true;
      var req = this.editEmployeeForm.getRawValue();
      this.employeeService.delete(req.Id).subscribe((resp)=>{
     
        this.employees.splice(this.index, 1);
        this.saving = false;
        this.closebutton.nativeElement.click();
      }, (err)=>{
        this.saving = false;
        alert("An error occurred.");
      });
  }
  update(){
   
    if(this.editEmployeeForm.valid){
      this.saving = true;
      var req = this.editEmployeeForm.getRawValue();
      this.employeeService.put(req).subscribe((resp)=>{
        debugger;
        this.employees[this.index] = {
          name: req.Name,
          id: req.Id,
          active: req.Active
        };
        this.saving = false;
        this.closebutton.nativeElement.click();
      }, (err)=>{
        this.saving = false;
        this.closebutton.nativeElement.click();
        alert("An error occurred.");
      });
    }
  
  }

  addEmployee(){
    if(this.addEmployeeForm.valid)
    {
      this.saving = true;
      var req = this.addEmployeeForm.getRawValue();
      this.employeeService.post(req).subscribe((resp)=>{
        
          this.employees.push({
            name: req.Name,
            active: req.Active,
            id: resp
          });

          this.addEmployeeForm.reset();
          this.saving = false;
          this.addEmployeeForm.get('Active').patchValue(false);
      },(error)=>{
        this.saving = false;
        this.closebutton.nativeElement.click();
        alert("An error occurred.");
      });
    }
  }

}
