import { Component } from '@angular/core';
import { LoginService } from 'src/app/services/login.service';


@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent {
  usuario
  constructor(public loginService: LoginService) { 
    var objeto = JSON.parse(JSON.parse(localStorage.getItem('usuario')));
    this.usuario = objeto.User;  
  }
 
}
