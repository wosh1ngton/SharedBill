import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DespesasComponent } from './components/despesas/despesas.component';
import { NavbarComponent } from './components/shared/navbar/navbar.component';
import { MatComponentsModule } from './mat-components.module';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { ListaDeDespesasComponent } from './components/lista-de-despesas/lista-de-despesas.component';
import { HomeComponent } from './components/home/home.component';
import { DespesasDialogComponent } from './components/despesas-dialog/despesas-dialog.component';
import { ConfirmationDialogComponent } from './components/shared/confirmation-dialog/confirmation-dialog.component';
import { LoginComponent } from './components/login/login.component';
import { RouterModule, Routes } from '@angular/router';
import { authGuard } from './services/login.service';
import { JwtModule } from '@auth0/angular-jwt';
import { LoadingComponent } from './components/loading/loading.component';

const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'login', component: LoginComponent },
  { path: 'home', component: HomeComponent, canActivate: [authGuard] },
];
export function tokenGetter() {
  return localStorage.getItem("jwt");
}
@NgModule({
  declarations: [
    AppComponent,
    DespesasComponent,
    NavbarComponent,
    ListaDeDespesasComponent,
    HomeComponent,
    DespesasDialogComponent,
    ConfirmationDialogComponent,
    LoginComponent,
    LoadingComponent 
  ],
  imports: [
    BrowserModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ["localhost:5008","localhost:5247",],
        disallowedRoutes: []
      }
    }),
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    MatComponentsModule,
    RouterModule.forRoot(routes)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
