import { AlertifyService } from './../../services/alertify.service';
import { Component, OnInit } from '@angular/core';
import { Employee } from '../../models/Employee';
import { EmployeeService } from '../../services/employee.service';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent implements OnInit {
  employees: Employee[];

  constructor(private employeeService: EmployeeService, private alertify: AlertifyService) { }

  ngOnInit() {
    this.load();
  }

  private load() {
    this.employeeService.getAllEmployees()
    .subscribe(data => {
      this.employees = data;
    });
  }

  deleteEmployee(employeeId: number){
    const employee = this.employees.find(x => x.id == employeeId);
    this.alertify.confirm("Remove", "Are you sure to remove " + employee.fullName +"?", () => {
      this.employeeService.deleteEmployee(employeeId)
        .subscribe(data => {
          this.load();
        });
    }, () => {
      this.alertify.error("Error");
    });
    
  }
}
