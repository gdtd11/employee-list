import { EmployeeFormComponent } from './components/employee-form/employee-form.component';
import { Routes } from '@angular/router';
import { EmployeeListComponent } from './components/employee-list/employee-list.component';

export const appRoutes: Routes = [
    { path: '', component: EmployeeListComponent},
    { path: 'employee', component: EmployeeFormComponent},
    { path: 'employees', component: EmployeeListComponent },
    {path: '**', redirectTo: '', pathMatch: 'full'}
];
