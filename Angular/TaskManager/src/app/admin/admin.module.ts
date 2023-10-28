import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardComponent } from './dashboard/dashboard.component';
import { AboutComponent } from './about/about.component';
import { MyProfileComponent } from './my-profile/my-profile.component';
import { DashboardService } from '../dashboard.service';
import { ProjectsComponent } from './projects/projects.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LoginComponent } from '../login/login.component';
import { ClientLocationStatusValidatorDirective } from '../client-location-status-validator.directive';
import { ProjectNameUniqueValidatorDirective } from '../project-name-unique-validator.directive';
import { ProjectComponent } from './project/project.component';
import { CheckBoxPrinterComponent } from './check-box-printer/check-box-printer.component';
import { NumberToWOrdsPipe } from '../number-to-words.pipe';
import { FilterPipe } from '../filter.pipe';
import { PagingPipe } from '../paging.pipe';
import { AlertDirective } from '../alert.directive';

@NgModule({
  declarations: [
    DashboardComponent,
    AboutComponent,
    MyProfileComponent,
    ProjectsComponent,
    LoginComponent,
    ClientLocationStatusValidatorDirective,
    ProjectNameUniqueValidatorDirective,
    ProjectComponent,
    CheckBoxPrinterComponent,
    NumberToWOrdsPipe,
    FilterPipe,
    PagingPipe,
    AlertDirective
    
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule
  ],
  exports:[
    DashboardComponent,
  MyProfileComponent,
  AboutComponent,
  ProjectsComponent,
  LoginComponent,
  ClientLocationStatusValidatorDirective,
  ProjectNameUniqueValidatorDirective,
  ProjectComponent,
  CheckBoxPrinterComponent
  
  ],
  providers:[DashboardService]
})
export class AdminModule { }
