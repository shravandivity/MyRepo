import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardComponent } from './dashboard/dashboard.component';
import { AboutComponent } from './about/about.component';
import { MyProfileComponent } from './my-profile/my-profile.component';
import { DashboardService } from '../dashboard.service';
import { ProjectsComponent } from './projects/projects.component';
import { FormsModule } from '@angular/forms';
import { LoginComponent } from '../login/login.component';
import { ClientLocationStatusValidatorDirective } from '../client-location-status-validator.directive';
import { ProjectNameUniqueValidatorDirective } from '../project-name-unique-validator.directive';

@NgModule({
  declarations: [
    DashboardComponent,
    AboutComponent,
    MyProfileComponent,
    ProjectsComponent,
    LoginComponent,
    ClientLocationStatusValidatorDirective,
    ProjectNameUniqueValidatorDirective
    
  ],
  imports: [
    CommonModule,
    FormsModule
  ],
  exports:[
    DashboardComponent,
  MyProfileComponent,
  AboutComponent,
  ProjectsComponent,
  LoginComponent,
  ClientLocationStatusValidatorDirective,
  ProjectNameUniqueValidatorDirective
  
  ],
  providers:[DashboardService]
})
export class AdminModule { }
