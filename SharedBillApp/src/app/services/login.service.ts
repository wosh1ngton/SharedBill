import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { environment } from 'src/environments/environment';
import { login } from '../models/login';
import { IAuthenticatedResponse } from '../models/IAuthenticatedResponse';
import { Observable, catchError, of, tap, throwError } from 'rxjs';
import { ActivatedRouteSnapshot, CanActivateFn, Router, RouterStateSnapshot } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})

export class LoginService {
  private readonly baseUrl = environment.loginUrlAPI;
  
  
  constructor(private http: HttpClient, public router: Router,
    private jwtHelper: JwtHelperService) { }


  // get isLoggedIn(): boolean {
  //   const usuario = JSON.parse(localStorage.getItem('usuario'));
  //   return (usuario !== null) ? true : false;
  // }
  // get isLoggedIn(): boolean {
  //   let jwtHelper = new JwtHelperService();
  //   const usuario = JSON.parse(localStorage.getItem('usuario'));
  //   return (usuario !== null) ? true : false;
  // }

  canActivate(route: ActivatedRouteSnapshot,state: RouterStateSnapshot) {
    const token = localStorage.getItem("jwt");
    if(token && !this.jwtHelper.isTokenExpired(token)) {
      console.log(this.jwtHelper.decodeToken(token));
      return true;
    }

    // let checkLogin = this.isLoggedIn;
      
    this.router.navigate(['login']);
    // if (!checkLogin) {
    //   return false;
    // }
    return false;
  }


  logar(usuario: login): Observable<any> {      
    const headers = new HttpHeaders({
      'Content-Type':'application/json'      
    });   
    return this.http.post<IAuthenticatedResponse>(this.baseUrl + 'Login/login', usuario, 
    { headers: headers});
  }
  
  Logout() {   
      this.http.get(this.baseUrl+'Login/logout').subscribe((val) => console.log(val));
      localStorage.removeItem('jwt');
      this.router.navigate(['']);    
  }

  currentUser(): string {
    const token = localStorage.getItem("jwt");
    var username = this.jwtHelper.decodeToken(token)
    return username.unique_name;
  }

}

export const authGuard: CanActivateFn = (route: ActivatedRouteSnapshot, state: RouterStateSnapshot) => {
  return inject(LoginService).canActivate(route,state);
}