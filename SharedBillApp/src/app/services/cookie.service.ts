import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
  })
export class CookieService {
  setCookie(name: string, value: string, expires: number, path: string) {
    const now = new Date();
    now.setTime(now.getTime() + expires * 1000); // Expires in seconds

    const expiresDate = `expires=${now.toUTCString()}`;
    const pathString = `path=${path}`;

    document.cookie = `${name}=${encodeURIComponent(value)}; ${expiresDate}; ${pathString}`;
  }
  // deleteCookie(name:string) {
  //   document.cookie = name +'=; Path=/;';
  // }

  
}