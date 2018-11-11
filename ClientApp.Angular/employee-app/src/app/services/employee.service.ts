import { Injectable } from '@angular/core';
import { Employee } from '../models/Employee';
import { HttpSpinnerService } from './http-spinner.service';

@Injectable()
export class EmployeeService {

  constructor(private httpSpinner: HttpSpinnerService) { }

  getAllEmployees() {
    return this.httpSpinner.get<Employee[]>('/employees');
  }

  createEmployee(employee: Employee) {
    return this.httpSpinner.post('/employees/', employee);
  }

   deleteEmployee(employeeId: number) {
     return this.httpSpinner.delete('/employees/' + employeeId);
   }
}
