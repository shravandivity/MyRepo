import { Directive } from '@angular/core';
import { AbstractControl, AsyncValidator, NG_ASYNC_VALIDATORS, ValidationErrors, Validator } from '@angular/forms';
import { Observable, map } from 'rxjs';
import { ProjectsService } from './projects.service';
import { Project } from './project';

@Directive({
  selector: '[appProjectNameUniqueValidator]',
  providers:[ {provide:NG_ASYNC_VALIDATORS, useExisting:ProjectNameUniqueValidatorDirective, multi:true}]
})
export class ProjectNameUniqueValidatorDirective implements AsyncValidator {

  constructor(private projectService : ProjectsService) { }

  validate(control: AbstractControl): Observable<ValidationErrors | null> {
    //console.log(control.value);
    return this.projectService.getProjectByName(control.value).pipe(map((existingProject : Project)=>{
      
      if(existingProject != null)
      {
        //console.log('Project Exists');
        return {uniqueProjectName:{valid : false}};
      }
      else
      {
        //console.log('Project not Exists');
        return null;
      }
    }));
  }
 
 
}
