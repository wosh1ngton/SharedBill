import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { login } from 'src/app/models/login';
import { IAuthenticatedResponse } from 'src/app/models/IAuthenticatedResponse';
import { CookieService } from 'src/app/services/cookie.service';
import { LoginService } from 'src/app/services/login.service';
//import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent  {
  invalidLogin:boolean;
  error: any;
  login: login = new login();
  

  constructor(private loginService: LoginService, 
    public router: Router,
    private cookieService: CookieService
    ) { }
 

  submit() {
    this.loginService.logar(this.login).subscribe({
      next: (response:IAuthenticatedResponse) => {   
        const token = response.token;               
        localStorage.setItem("jwt",token);  
        this.invalidLogin = false;    
        return this.router.navigate(['home']);
      },
      error: (err) => {
        console.log(err, 'erro');
        this.invalidLogin=true;
        return this.error = 'Login inválido';
      }
    });
  }

  

}

