import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class JwtService {

  constructor() { }

  public decodeToken(token: string) {
    try {
      const payload = token.split('.')[1];
      return JSON.parse(atob(payload));
    } catch {
      throw new Error('Invalid token format');
    }
  }

}
