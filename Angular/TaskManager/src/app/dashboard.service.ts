import { Injectable } from '@angular/core';

@Injectable()
export class DashboardService {

  constructor() { }

  getTeamMembersSummary():any[]
  {
    var TeamMembersSummary = [
      {Region:"East",TeamMembersCount:25,TemporayUnavailableMembers:4,},
      {Region:"West",TeamMembersCount:15,TemporayUnavailableMembers:8,},
      {Region:"North",TeamMembersCount:19,TemporayUnavailableMembers:1,},
      {Region:"South",TeamMembersCount:15,TemporayUnavailableMembers:6,},
    ];
    return TeamMembersSummary;
  }
}
