import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, FormGroupName, Validators } from '@angular/forms';
import { CountriesService } from '../countries.service';
import { Country } from '../country';
import { JsonPipe } from '@angular/common';
import { CustomValidatorsService } from '../custom-validators.service';
import { SignUpViewModel } from '../sign-up-view-model';
import { LoginService } from '../login.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.scss']
})
export class SignUpComponent implements OnInit {

  signUpForm:FormGroup | any = null;
  genders=["Male","Female"];
  countries:Country[] =[];
  registerError:string|any;
  constructor(private countryService:CountriesService, private formBuilder:FormBuilder, private customValidator:CustomValidatorsService, private loginService:LoginService, private router:Router) { }
  @ViewChild("firstName") firstName:ElementRef|any = null;
  fieldTextType: boolean|any;
  repeatFieldTextType: boolean|any;
  ngOnInit(): void {
    this.countryService.getCountries().subscribe(
      (response)=>{
        this.countries = response;
      },
      (error)=>{
        console.log(error);
      });
    //this.countries = this.countryService.getCountries();

    this.signUpForm = this.formBuilder.group({
      personName: this.formBuilder.group({
        firstName:[null,[Validators.required, Validators.minLength(2)]],
      lastName:[null,[Validators.required, Validators.minLength(2)]],
      }),
      email:[null,[Validators.required,Validators.email],[this.customValidator.duplicateEmailValidator()],{updateOn:'blur'}],
      mobile:[null,[Validators.required]],
      dateOfBirth:[null,[Validators.required,this.customValidator.minimumAgeValidator(18)]],
      password:[null,[Validators.required, Validators.minLength(6)]],
      confirmPassword:[null,[Validators.required]],
      gender:[null,[Validators.required]],
      countryID:[null,[Validators.required]],
      recieveNewsLetters:new FormControl(null),
      skills:this.formBuilder.array([])
    },
    {
      validators:[
        this.customValidator.compareValidator("confirmPassword","password")
      ]
    });

    this.signUpForm.valueChanges.subscribe((value:any)=>{
      //console.log(value);
    });
    setTimeout(()=>{
      this.firstName.nativeElement.focus();
    },100);
  }

  onSubmitClick(){
    
    if(this.signUpForm.valid)
    {
      var signUpViewModel = this.signUpForm.value as SignUpViewModel;
      //var data = JSON.stringify(signUpViewModel);
      //alert(data);
      
      this.loginService.Register(signUpViewModel).subscribe(
        (response)=>{
          this.router.navigateByUrl("/tasks")
        },
        (error)=>{
          console.log(error);
          this.registerError = "Unable to register.";
        });
    }
    console.log(this.signUpForm.value);
  }

  onAddSkill(){
    var formGroup = this.formBuilder.group({
      skillName:[null,[Validators.required, Validators.minLength(2)]],
      skillLevel:[null,[Validators.required]]
    });
    (<FormArray> this.signUpForm.get('skills')).push(formGroup);
  }

  onRemoveSkill(i:number){
    (<FormArray> this.signUpForm.get('skills')).removeAt(i);
  }

  toggleFieldTextType() {
    this.fieldTextType = !this.fieldTextType;
  }

  toggleRepeatFieldTextType() {
    this.repeatFieldTextType = !this.repeatFieldTextType;
  }

}
