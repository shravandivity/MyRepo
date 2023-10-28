import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { Project } from './project';
import { Observable, Observer, Subject } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class ProjectsService {

// public MyObservable:Observable<boolean>|any = null;
// private MyObservers:Observer<boolean>[]|any=[];
public MySubject:Subject<boolean>|any = null;

hideDetails:boolean = false;
  constructor(private httpClient : HttpClient) 
  {
    // this.MyObservable = new Observable(
    //   (observer:Observer<boolean>)=>{
    //     this.MyObservers.push(observer);
    //   });

    this.MySubject = new Subject<boolean>();
  }
 toggleDetails()
  {
    this.hideDetails = !this.hideDetails;
    // for(let i = 0;i < this.MyObservers.length; i++)
    // {
    //   this.MyObservers[i].next(this.hideDetails);
    // }
    this.MySubject.next(this.hideDetails);
  }

  getAllProjects():Observable<Project[]>
  {
    // var currentUser = {token:''};
    // var headers = new HttpHeaders();
    // headers = headers.set("Authorization","Bearer ");
    
    // if(sessionStorage.getItem('currentUser') != null)
    // {
    //   currentUser = JSON.parse(sessionStorage.getItem('currentUser')!);
    //   headers = headers.set("Authorization", "Bearer " + currentUser.token);
    // }
    //alert('Project service:' + currentUser.token);
    
    return this.httpClient.get<Project[]>("/api/Projects",{responseType:'json'});
  }

  getProjectByName(projectname:string):Observable<Project>
  {
    //console.log(id);
    //alert(projectname);
    return this.httpClient.get<Project>("/api/projects/GetProjectByName/" + projectname,{responseType:'json'});
    //return this.httpClient.get<Project>("/api/projects/GetProjectById/" + id,{responseType:'json'});
  }
  insertProject(newProject : Project):Observable<Project>
  {
    return this.httpClient.post<Project>("/api/Projects",newProject,{responseType:'json'});
  }

  updateProject(project : Project):Observable<Project>
  {
    return this.httpClient.put<Project>("/api/projects",project,{responseType:'json'});
  }

  deleteProject(id:number):Observable<string>
  {
    return this.httpClient.delete<string>("/api/projects/"+id);
  }

  SearchProjects(searchby:string,searchtext:string):Observable<Project[]>
  {
    return this.httpClient.get<Project[]>("/api/projects/search/"+searchby+"/"+searchtext,{responseType:'json'});
  }

  GetHttpHeaders() : HttpHeaders
  {
    var currentUser = {token:''};
    var headers = new HttpHeaders();
    headers = headers.set("Authorization","Bearer ");
    
    if(sessionStorage.getItem('currentUser') != null)
    {
      currentUser = JSON.parse(sessionStorage.getItem('currentUser')!);
      headers = headers.set("Authorization", "Bearer " + currentUser.token);
    }
    return headers;
  }
}
