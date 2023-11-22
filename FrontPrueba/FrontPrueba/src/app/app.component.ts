import { MatSidenav } from '@angular/material/sidenav';
import { Component, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { LoginComponent } from './auth/login/login.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'FrontPrueba';
  @ViewChild('sidenav') sidenav: MatSidenav = null!;
  constructor(public dialog: MatDialog) { }

  abrirLogin(): void {
    this.dialog.open(LoginComponent, {
      width: '400px',
      // Puedes agregar más opciones de configuración aquí si es necesario
    });
  }
}
