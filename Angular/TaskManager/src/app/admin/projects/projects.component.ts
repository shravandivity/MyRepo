import { Component, ElementRef, OnInit, QueryList, ViewChild, ViewChildren } from '@angular/core';
import { ProjectsService } from 'src/app/projects.service';
import { Project } from 'src/app/project';
import { formatDate } from '@angular/common';
import { DatePipe } from '@angular/common';
import { ClientLocation } from 'src/app/client-location';
import { ClientLocationsService } from 'src/app/client-locations.service';
import { NgForm } from '@angular/forms';
import * as $ from 'jquery';
import { ProjectComponent } from '../project/project.component';
import { FilterPipe } from 'src/app/filter.pipe';

@Component({
  selector: 'app-projects',
  templateUrl: './projects.component.html',
  styleUrls: ['./projects.component.scss']
})
export class ProjectsComponent implements OnInit {

  projects: Project[] = [];
  clientLocations:ClientLocation[] =[];
  showLoading:boolean = true;
  newProject:Project = new Project();
  editProject:Project = new Project();
  editIndex:any = null;
  deleteProject:Project = new Project();
  deleteIndex:any=null;
  searchby:string="projectName";
  searchtext:string="";
  @ViewChild("newForm") newForm:NgForm | any = null;
  @ViewChild("editForm") editForm:NgForm | any = null
  isAllChecked:boolean = false;
  @ViewChildren("prj") prj:QueryList<ProjectComponent>|any = null
  @ViewChild("prjNameNew") prjNameNew:ElementRef|any = null;
  @ViewChild("prjNameEdit") prjNameEdit:ElementRef|any = null;
  currentPageIndex:number=0;
  pages:any[]=[];
  pageSize:number=3;
  constructor(private projectsService : ProjectsService, private clientLocationService : ClientLocationsService) {
    
   }

  ngOnInit(): void {
    
    this.projectsService.getAllProjects().subscribe(
      (response:Project[])=>{
        //alert('ngOnOinit');
        //alert(this.projects.length);
        //for(let i = 0; i < this.projects.length; i++)
        //{
          //alert(this.projects[i].dateOfStart);alert(this.projects[i].dateOfStart);
        //}
        //alert(this.projects[0].dateOfStart);
        
        this.projects=response;
        this.showLoading = false;
        this.calculateNoOfPages();
      }
    );

    this.clientLocationService.getClientLocations().subscribe(
      (response:ClientLocation[])=>{
        this.clientLocations = response;
      });
  }

  onNewClick(event:any){
    this.newForm.resetForm();
    setTimeout(()=>{
      this.prjNameNew.nativeElement.focus();
    },100);
  }

  onSaveClick(){
    if(this.newForm.valid)
    {
      //alert('Hello');
      //alert(this.newProject.dateOfStart);
      //this.newProject.clientLocationId = 0;
      this.projectsService.insertProject(this.newProject).subscribe(
        (response:Project)=>{
          this.newProject = response
          this.projects.push(this.newProject);
          this.newProject = new Project();

          $('#newFormCancel').trigger("click");
          this.calculateNoOfPages();
        },(error)=>{console.log(error)}
      );
    }
    
  }

  onEditClick(event:any, index:number){
    
    this.editForm.resetForm();
    setTimeout(()=>{
      this.editProject.projectID = this.projects[index].projectID;
      this.editProject.projectName = this.projects[index].projectName;
      this.editProject.dateOfStart = this.projects[index].dateOfStart ;
      this.editProject.teamSize = this.projects[index].teamSize;
      this.editProject.active = this.projects[index].active;
      this.editProject.status = this.projects[index].status;
      this.editProject.clientLocationId = this.projects[index].clientLocationId;
      this.editProject.clientLocation = this.projects[index].clientLocation;
  
      this.editIndex = index;
      let newDate = new Date(this.editProject.dateOfStart);
      let formattedDate = formatDate(newDate, 'yyyy-MM-dd', 'en-US');  
      //alert(this.editProject.dateOfStart);
      //alert(formattedDate);
      this.editProject.dateOfStart = formattedDate;
      this.prjNameEdit.nativeElement.focus();
    }, 100);
  }

  onUpdateClick(){
    if(this.editForm.valid)
    {
      this.projectsService.updateProject(this.editProject).subscribe(
        (response)=>{
          this.editProject = response;
          this.projects[this.editIndex] = this.editProject;
          this.editProject = new Project();
          this.editIndex = null;

          $('#editFormCancel').trigger("click");
        },
        (error) =>{
          console.log(error);
        });
    }
    
  }

  onDeleteClick(event:any, index:number){
    this.deleteProject.projectID = this.projects[index].projectID;
    this.deleteProject.projectName = this.projects[index].projectName;
    this.deleteProject.dateOfStart = this.projects[index].dateOfStart ;
    this.deleteProject.teamSize = this.projects[index].teamSize;
    this.deleteProject.active = this.projects[index].active;
    this.deleteProject.status = this.projects[index].status;
    this.deleteProject.clientLocationId = this.projects[index].clientLocationId;
    this.deleteProject.clientLocation = this.projects[index].clientLocation;
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
        this.calculateNoOfPages();
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

  // @ViewChildren("prj") prj:QueryList<ProjectComponent>|any = null;

  onHideShowDetails(event:any)
  {
    // let projs = this.prj.toArray();
    // for(let i = 0; i < this.prj.length; i++)
    // {
    //    projs[i].toggleDetails();
    // }
    this.projectsService.toggleDetails();
  }

  isAllCheckedChange(event:any)
  {
    let projs = this.prj.toArray();
    for(let i = 0; i < this.prj.length; i++)
    {
       projs[i].isAllCheckedChange(this.isAllChecked);
    }
  }

  calculateNoOfPages()
  {
    let filterPipe = new FilterPipe();
    var resultProjects = filterPipe.transform(this.projects, this.searchby, this.searchtext);
    var noOfPages = Math.ceil(resultProjects.length/this.pageSize);
    //console.log(noOfPages);
    this.pages=[];
    for(let i = 0; i < noOfPages; i++)
    {
      this.pages.push({pageIndex : i});
    }
    this.currentPageIndex = 0;
  }

  onSearchTextKeyUp(eventy:any)
  {
    this.calculateNoOfPages();
  }

  onPageIndexClicked(pageIndex:number)
  {
    this.currentPageIndex = pageIndex;
  }
}
