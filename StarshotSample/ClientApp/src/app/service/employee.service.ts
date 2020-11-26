import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Base } from './base';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService extends Base {

 
  constructor(private httpClient: HttpClient) 
  { 
    super();
  }
  
  public get(search = "", active = 0){
    var header = this.headers;
  
    return this.httpClient.get(`employee?search=${search}&active=${active}`, {
      headers: header
    });
  }
  public put(req: any){
    return this.httpClient.put(`employee`, req,  {
      headers: this.headers
    });
  }

  public post(req: any){

    return this.httpClient.post(`employee`, req,  {
      headers: this.headers
    });
  }

  public delete(id: number){
  
    return this.httpClient.delete(`employee?Id=${id}`,  {
      headers: this.headers
    });
  }

  public attendance(date: Date){
    var header = this.headers;
  
    return this.httpClient.get(`employee/attendance?date=${date.toISOString()}`, {
      headers: header
    });
  }

  public timein(id: any, date: Date){

    return this.httpClient.post(`employee/timein?employeeId=${id}&date=${date.toISOString()}`, null,  {
      headers: this.headers
    });
  }

  public timeout(id: any, date: Date){
   
    return this.httpClient.post(`employee/timeout?employeeId=${id}&date=${date.toISOString()}`, null,  {
      headers: this.headers
    });
  }
}
