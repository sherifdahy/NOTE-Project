import { Injectable } from '@angular/core';
import { AuthResponse } from '@app/shared/models';
import { STORAGE_KEY_CONSTS } from '@app/shared/constants';

@Injectable({
  providedIn: 'root'
})
export class AuthStorageService {

  get(): AuthResponse | null {
    return JSON.parse(localStorage.getItem(STORAGE_KEY_CONSTS.AUTH.TOKEN_OBJ) as string);
  }

  save(authResponse: AuthResponse): void {
    localStorage.setItem(
      STORAGE_KEY_CONSTS.AUTH.TOKEN_OBJ,
      JSON.stringify(authResponse)
    );
  }

  remove(): void {
    localStorage.removeItem(STORAGE_KEY_CONSTS.AUTH.TOKEN_OBJ);
  }
}
