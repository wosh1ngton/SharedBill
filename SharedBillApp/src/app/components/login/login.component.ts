import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { login } from 'src/app/models/login';
import { CookieService } from 'src/app/services/cookie.service';
import { LoginService } from 'src/app/services/login.service';
//import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent  {

  error: any;
  login: login = new login();
  

  constructor(private loginService: LoginService, 
    public router: Router,
    private cookieService: CookieService
    ) { }
 

  submit() {
    this.loginService.logar(this.login).subscribe({
      next: (val) => {              
        var arrayCookie = val.replaceAll('=','$').replaceAll(';','$').split('$');               
        localStorage.setItem('usuario', JSON.stringify(val));
        this.cookieService.setCookie('.AspNet.SharedCookie',arrayCookie[1],3600,'/');       
        return this.router.navigate(['home']);
      },
      error: (err) => {
        console.log(err, 'erro');
        return this.error = 'Login inválido';
      }
    });
  }

  

}

