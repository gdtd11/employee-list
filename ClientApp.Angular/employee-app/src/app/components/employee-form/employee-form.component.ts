import { AlertifyService } from './../../services/alertify.service';
import { JobService } from './../../services/job.service';
import { Job } from './../../models/Job';
import { Component, OnInit } from '@angular/core';
import { Employee } from '../../models/Employee';
import { ActivatedRoute } from '@angular/router';
import { EmployeeService } from '../../services/employee.service';

@Component({
  selector: 'app-category-form',
  templateUrl: './employee-form.component.html',
  styleUrls: ['./employee-form.component.css']
})
export class EmployeeFormComponent implements OnInit {
  jobList: Job[];

  isJobTitleHasError: boolean;

  selectedItems = [];
  dropdownSettings = {};

  employee: Employee = {
    id: 0,
    lastName: '',
    firstName: '',
    employmentDate: '',
    rate: null,
    jobs: [],
    fullName: ''
  };

  constructor(private route: ActivatedRoute, 
              private employeeService: EmployeeService, 
              private jobService: JobService,
              private alertify: AlertifyService) {
   }

  ngOnInit() {
    this.isJobTitleHasError = false;

     this.jobService.getAllJobs()
    .subscribe(data => {
      this.jobList = data;
    });

    this.dropdownSettings = {
      singleSelection: false,
      idField: 'id',
      textField: 'title',
      selectAllText: 'Select All',
      unSelectAllText: 'UnSelect All',
      itemsShowLimit: 3,
      allowSearchFilter: false,
      enableCheckAll: false,
    };
  }

  onItemSelect(item: Job) {
    //console.log(item);
    this.employee.jobs.push(item.id);
    this.validateJobTilte();
  }

  onItemDeSelect(item: Job){
    console.log(item);
    const index: number = this.employee.jobs.indexOf(item.id);
    if (index !== -1) {
        this.employee.jobs.splice(index, 1);
    }  

  }

  createEmployee() {  
    this.validateJobTilte();

    if (this.isJobTitleHasError)
      return;

      this.employeeService.createEmployee(this.employee)
       .subscribe(() => {
        this.alertify.success("Employee Created");
       }, (error) => {
        this.alertify.error("Employee already exist");
       });
  }

  validateJobTilte() {
    if (this.employee.jobs.length > 0)
      this.isJobTitleHasError = false;
    else
      this.isJobTitleHasError = true;
  }

}
