import { Component, OnInit } from '@angular/core';
import { ProjectsService } from 'src/app/projects.service';
import { Project } from 'src/app/project';
import { formatDate } from '@angular/common';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-projects',
  templateUrl: './projects.component.html',
  styleUrls: ['./projects.component.scss']
})
export class ProjectsComponent implements OnInit {

  projects: Project[] = [];
  newProject:Project = new Project();
  editProject:Project = new Project();
  editIndex:any = null;
  deleteProject:Project = new Project();
  deleteIndex:any=null;
  searchby:string="";
  searchtext:string="";

  constructor(private projectsService : ProjectsService) {
    
   }

  ngOnInit(): void {
    this.projectsService.getAllProjects().subscribe(
      (response:Project[])=>{
        this.projects=response;
      }
    );
  }

  onSaveClick(){
    //alert('Hello');
    //alert(this.newProject.dateOfStart);
    this.projectsService.insertProject(this.newProject).subscribe(
      (response:Project)=>{
        this.newProject = response
        this.projects.push(this.newProject);
        this.newProject = new Project();
      },(error)=>{console.log(error)}
    );
  }

  onEditClick(event:any, index:number){
    this.editProject.projectID = this.projects[index].projectID;
    this.editProject.projectName = this.projects[index].projectName;
    this.editProject.dateOfStart = this.projects[index].dateOfStart ;
    this.editProject.teamSize = this.projects[index].teamSize;
    this.editIndex = index;
    let newDate = new Date(this.editProject.dateOfStart);
    let formattedDate = formatDate(newDate, 'yyyy-MM-dd', 'en-US');  
    //alert(this.editProject.dateOfStart);
    //alert(formattedDate);
    this.editProject.dateOfStart = formattedDate;
  }

  onUpdateClick(){
    this.projectsService.updateProject(this.editProject).subscribe(
      (response)=>{
        this.editProject = response;
        this.projects[this.editIndex] = this.editProject;
        this.editProject = new Project();
        this.editIndex = null;
      });
  }

  onDeleteClick(event:any, index:number){
    this.deleteProject.projectID = this.projects[index].projectID;
    this.deleteProject.projectName = this.projects[index].projectName;
    this.deleteProject.dateOfStart = this.projects[index].dateOfStart ;
    this.deleteProject.teamSize = this.projects[index].teamSize;
    this.deleteIndex = index;
    let newDate = new Date(this.deleteProject.dateOfStart);
    let formattedDate = formatDate(newDate, 'yyyy-MM-dd', 'en-US');  
    //alert(this.editProject.dateOfStart);
    //alert(formattedDate);
    this.deleteProject.dateOfStart = formattedDate;
  }

  onDeleteConfirmClick(){
    this.projectsService.deleteProject(this.deleteProject.projectID).subscribe(
      (response)=>{
        this.projects.splice(this.deleteIndex,1);
        this.deleteProject = new Project();
        this.deleteIndex = null;
      },
      (error)=>{
        console.log(error);
      }
    );
  }

  onSearchClick(){
    this.projectsService.SearchProjects(this.searchby,this.searchtext).subscribe(
      (response:Project[])=>{
        this.projects=response;
      },
      (error)=>{
        console.log(error);
      }
    );
  }
}
