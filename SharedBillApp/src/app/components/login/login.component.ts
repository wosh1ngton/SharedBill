import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';
import { login } from 'src/app/models/login';
import { LoginService } from 'src/app/services/login.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  
  error:any;
  login: login = new login();    
  
  constructor(private loginService: LoginService, public router: Router) {  } 

  submit() {
    this.loginService.logar(this.login).subscribe({
      next: (val) => {
      localStorage.setItem('usuario', JSON.stringify(val));          
      return this.router.navigate(['home']);
    },
    error: (err) => {console.log('erro');
      return this.error = 'Login inválido';
    }
    
  });

  } 

}

