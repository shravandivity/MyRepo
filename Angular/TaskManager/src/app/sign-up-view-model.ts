export class SignUpViewModel {
    personName:any;
    email:string|any;
    mobile:string|any;
    dateOfBirth:|string|any;
    password:string|any;
    gender:string|any;
    countryID:number|any;
    recieveNewsLetters:boolean|any;
    skills:any;

    /**
     *
     */
    constructor(
        personName:any = null,
        email:string|any = null,
        mobile:string|any = null,
        dateOfBirth:|string|any = null,
        password:string|any = null,
        gender:string|any = null,
        countryID:number|any = null,
        recieveNewsLetters:boolean|any = null,
        skills:any = null
    ) {
       
        this.personName = personName;
        this.email = email;
        this.mobile = mobile;
        this.dateOfBirth = dateOfBirth;
        this.password = password;
        this.gender = gender;
        this.countryID = countryID;
        this.recieveNewsLetters = recieveNewsLetters;
        this.skills = skills;
    }
}
