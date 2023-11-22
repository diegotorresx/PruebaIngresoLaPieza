import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private loggedIn = new BehaviorSubject<boolean>(false); // Inicialmente, el usuario no está autenticado

  get isLoggedIn() {
    return this.loggedIn.asObservable(); // Retorna un observable para que los componentes puedan subscribirse
  }

  login(username: string, password: string): boolean {
    // Aquí debes realizar tu lógica de autenticación (conexión a un API, etc.)
    // Por ejemplo, si el username es 'admin' y el password es 'password', permitir acceso:
    if (username === 'admin' && password === 'password') {
      this.loggedIn.next(true);
      return true;
    }
    return false;
  }

  logout() {
    this.loggedIn.next(false);
  }
}