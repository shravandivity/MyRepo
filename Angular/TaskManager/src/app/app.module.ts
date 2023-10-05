import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { JwtModule } from '@auth0/angular-jwt';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AdminModule } from './admin/admin.module';
import { HTTP_INTERCEPTORS, HttpClient, HttpClientModule } from '@angular/common/http';
import { LoginComponent } from './login/login.component';
import { JwtInterceptorService } from './jwt-interceptor.service';
import { JwtUnauthorizedInterceptorService } from './jwt-unauthorized-interceptor.service';
import { ClientLocationStatusValidatorDirective } from './client-location-status-validator.directive';
import { ProjectNameUniqueValidatorDirective } from './project-name-unique-validator.directive';
import { ReactiveFormsModule } from '@angular/forms';
import { SignUpComponent } from './sign-up/sign-up.component';
import { TasksComponent } from './tasks/tasks.component';



@NgModule({
  declarations: [
    AppComponent,
    SignUpComponent,
    TasksComponent
    
    
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    AdminModule,
    ReactiveFormsModule,
    JwtModule.forRoot({
      config:{
        tokenGetter:()=>{
          return (sessionStorage.getItem('currentUser') ? JSON.parse(sessionStorage.getItem('currentUser') as string).token:null);
        }
      }
    })
    
  ],
  providers: [
    {
      provide:HTTP_INTERCEPTORS,
      useClass:JwtInterceptorService,
      multi:true
    },
    {
      provide:HTTP_INTERCEPTORS,
      useClass:JwtUnauthorizedInterceptorService,
      multi:true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
