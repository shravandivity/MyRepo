import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { LoginViewModel } from '../login-view-model';
import { LoginService } from '../login.service';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginForm:FormGroup|any=null;
  loginViewModel:LoginViewModel = new LoginViewModel();
  loginError:string = "";
  fieldTextType: boolean|any;
  constructor(private loginService:LoginService, private router:Router, private formBuilder:FormBuilder) { }
  @ViewChild("userName") userName:ElementRef|any = null;
  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      userName:[null,[Validators.required,Validators.email]],
      password:[null,[Validators.required]]
    });
    setTimeout(()=>{
      this.userName.nativeElement.focus();
    },100);
  }

  onLoginClick(event:any)
  {
    if(this.loginForm.valid)
    {
      //alert(this.loginViewModel.UserName);
      //alert(this.loginViewModel.Password);
      this.loginService.Login(this.loginViewModel).subscribe(
        (response)=>{
          //alert('login component' + response.UserName);
          this.router.navigateByUrl("/dashboard")
        },
        (error)=>{
          console.log(error);
          this.loginError = "Invalid username or password";
        }
      );
    }
    
  }

  toggleFieldTextType() {
    this.fieldTextType = !this.fieldTextType;
  }
}
