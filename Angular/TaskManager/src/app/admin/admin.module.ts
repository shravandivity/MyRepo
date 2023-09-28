import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardComponent } from './dashboard/dashboard.component';
import { AboutComponent } from './about/about.component';
import { MyProfileComponent } from './my-profile/my-profile.component';
import { DashboardService } from '../dashboard.service';
import { ProjectsComponent } from './projects/projects.component';
import { FormsModule } from '@angular/forms';
import { LoginComponent } from '../login/login.component';

@NgModule({
  declarations: [
    DashboardComponent,
    AboutComponent,
    MyProfileComponent,
    ProjectsComponent,
    LoginComponent
    
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
  LoginComponent
  
  ],
  providers:[DashboardService]
})
export class AdminModule { }
