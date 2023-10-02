import { ClientLocation } from "./client-location";

export class Project {
    projectID:number;
    projectName:string;
    dateOfStart:string;
    teamSize:number;
    active:boolean;
    status:string;
    clientLocationId:number;
    clientLocation:ClientLocation;

    /**
     *
     */
    constructor() {
        this.projectID = 0;
        this.projectName = "";
        this.dateOfStart = Date.now().toString();
        this.teamSize = 0;
        this.active = false;
        this.status = '';
        this.clientLocationId = 0;
        this.clientLocation = new ClientLocation();
    }
}
