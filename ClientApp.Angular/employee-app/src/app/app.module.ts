import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { EmployeeFormComponent } from './components/employee-form/employee-form.component';
import { EmployeeService } from './services/employee.service';
import { HttpSpinnerService } from './services/http-spinner.service';
import { SpinnerLoaderService } from './services/spinner-loader.service';
import { appRoutes } from './routes';
import { SpinnerLoaderComponent } from './components/spinner-loader/spinner-loader.component';
import { EmployeeListComponent } from './components/employee-list/employee-list.component';
import { OwlDateTimeModule, OwlNativeDateTimeModule } from 'ng-pick-datetime';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';
import { AlertifyService } from './services/alertify.service';


@NgModule({
  declarations: [
    AppComponent,
    EmployeeFormComponent,
    SpinnerLoaderComponent,
    EmployeeListComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes),
    OwlDateTimeModule, 
    OwlNativeDateTimeModule,
    NgMultiSelectDropDownModule.forRoot()
  ],
  providers: [
    EmployeeService,
    HttpSpinnerService,
    SpinnerLoaderService,
    AlertifyService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
