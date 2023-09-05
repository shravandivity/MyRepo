import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  Designation:string;
  Username:string;
  NoOfTeamMembers:number;
  TotalCostOfAllProjects:number;
  PendingTasks:number;
  UpcomingProjects:number;
  ProjectCost:number;
  CurrentExpenditure:number;
  AvailableFunds:number;

  Clients:string[];
  Projects:string[];
  Years:number[];
  TeamMembersSummary:any[];
  TeamMembers:any[];


  constructor() { 

    this.Designation="Team Leader";
    this.Username="John Smith";
    this.NoOfTeamMembers=67;
    this.TotalCostOfAllProjects=240;
    this.PendingTasks=15;
    this.UpcomingProjects=2;
    this.ProjectCost=2113507;
    this.CurrentExpenditure=96788;
    this.AvailableFunds=5236;

    this.Clients = [
      "ABc Infotech","DEF Software Ltd","GHI Industries"
    ];
    this.Projects= [
      "Project A","Project B","Project C","Project D"
    ];
    this.Years = [];
    this.TeamMembersSummary = [
      {Region:"East",TeamMembersCount:20,TemporayUnavailableMembers:4,},
      {Region:"West",TeamMembersCount:15,TemporayUnavailableMembers:8,},
      {Region:"North",TeamMembersCount:19,TemporayUnavailableMembers:1,},
      {Region:"South",TeamMembersCount:15,TemporayUnavailableMembers:6,},
    ];
    this.TeamMembers = [
      {Region:"East",Members:[
        {ID:1,Name:"Ford",Status:"Available"},
        {ID:2,Name:"Miller",Status:"Available"},
        {ID:3,Name:"Jones",Status:"Busy"},
        {ID:4,Name:"James",Status:"Busy"}
      ]},
      {Region:"West",Members:[
        {ID:1,Name:"Anna",Status:"Available"},
        {ID:2,Name:"Varun",Status:"Available"},
        {ID:3,Name:"Arun",Status:"Busy"},
        {ID:4,Name:"Jasmine",Status:"Busy"}
      ]},
      {Region:"South",Members:[
        {ID:1,Name:"Krishna",Status:"Available"},
        {ID:2,Name:"Mohan",Status:"Available"},
        {ID:3,Name:"Raju",Status:"Busy"},
        {ID:4,Name:"Farooq",Status:"Busy"}
      ]},
      {Region:"North",Members:[
        {ID:1,Name:"Jacob",Status:"Available"},
        {ID:2,Name:"Smith",Status:"Available"},
        {ID:3,Name:"Jones",Status:"Busy"},
        {ID:4,Name:"James",Status:"Busy"}
      ]}
    ];
  }

  ngOnInit(): void {
    
  }

  onProjectChange(event:any){
    //console.log(event.target.innerHTML);
    if(event.target.innerHTML == "Project A")
    {
      this.ProjectCost = 2113507;
      this.CurrentExpenditure = 96788;
      this.AvailableFunds = 52436;
    }
    if(event.target.innerHTML == "Project B")
    {
      this.ProjectCost = 88923;
      this.CurrentExpenditure = 22450;
      this.AvailableFunds = 2640;
    }
    if(event.target.innerHTML == "Project C")
    {
      this.ProjectCost = 662183;
      this.CurrentExpenditure = 7721;
      this.AvailableFunds = 9811;
    }
    if(event.target.innerHTML == "Project D")
    {
      this.ProjectCost = 928431;
      this.CurrentExpenditure = 562;
      this.AvailableFunds = 883;
    }
  }

}
