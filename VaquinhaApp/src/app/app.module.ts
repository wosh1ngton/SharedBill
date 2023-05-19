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


@NgModule({
  declarations: [
    AppComponent,
    DespesasComponent,
    NavbarComponent,
    ListaDeDespesasComponent,
    HomeComponent,
    DespesasDialogComponent,
    ConfirmationDialogComponent 
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    MatComponentsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
