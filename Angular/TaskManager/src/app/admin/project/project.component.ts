import { Component, ContentChild, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Subscription } from 'rxjs';
import { Project } from 'src/app/project';
import { ProjectsService } from 'src/app/projects.service';
import { CheckBoxPrinterComponent } from '../check-box-printer/check-box-printer.component';

@Component({
  selector: 'app-project',
  templateUrl: './project.component.html',
  styleUrls: ['./project.component.scss']
})
export class ProjectComponent implements OnInit {
  @Input("currentProject") project:Project | any = null;
  @Input("recordIndex") i:number | any = null;

  @Output() editClick = new EventEmitter();
  @Output() deleteClick = new EventEmitter();
  @ContentChild("selectionBox") selectionBox : CheckBoxPrinterComponent|any = null;
  hideDetails:boolean = false;
  MySubscription:Subscription|any=null;

  constructor(public projectService:ProjectsService) { }

  ngOnInit(): void {
    // this.projectService.MyObservable.subscribe(
    //   (hide:boolean)=>{
    //     this.hideDetails = hide;
    //   });

    this.MySubscription = this.projectService.MySubject.subscribe(
      (hide:boolean)=>{
        this.hideDetails = hide;
      });
  }

  onEditClick(event:any, i:number){
    this.editClick.emit({event, i});
  }

  onDeleteClick(event:any, i:number){
    this.deleteClick.emit({event, i});
  }

  ngOnDestroy():void{
    this.MySubscription.unsubscribe();
  };
 
  isAllCheckedChange(check:boolean)
  {
    this.selectionBox.checkUnCheck(check);
  }

}
