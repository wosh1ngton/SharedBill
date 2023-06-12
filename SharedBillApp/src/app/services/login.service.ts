import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { environment } from 'src/environments/environment';
import { login } from '../models/login';
import { Observable, catchError, of, tap } from 'rxjs';
import { ActivatedRouteSnapshot, CanActivateFn, Router, RouterStateSnapshot } from '@angular/router';

@Injectable({
  providedIn: 'root'
})

export class LoginService {
  private readonly baseUrl = environment.loginUrlAPI;
  
  
  constructor(private http: HttpClient, public router: Router) { }


  get isLoggedIn(): boolean {
    const usuario = JSON.parse(localStorage.getItem('usuario'));
    return (usuario !== null) ? true : false;
  }

  canActivate(state: RouterStateSnapshot) {
    
    let checkLogin = this.isLoggedIn;
      
    if (!checkLogin) {
      this.router.navigate(['login']);
      return false;
    }
    return true;
  }

  logar(usuario: login): Observable<any> {
    console.log(usuario);
    return this.http.post(this.baseUrl + 'Login/login',usuario, { responseType: 'text' });
  }

  Logout() {   
      this.http.get(this.baseUrl+'Login/logout').subscribe((val) => console.log(val));
      localStorage.removeItem('usuario');
      this.router.navigate(['']);    
  }

  currentUser(): any {
    return this.http.get<any>(this.baseUrl + 'Login/usuarioLogado');
  }

}

export const authGuard: CanActivateFn = (route: ActivatedRouteSnapshot, state: RouterStateSnapshot) => {
  return inject(LoginService).canActivate(state);
}