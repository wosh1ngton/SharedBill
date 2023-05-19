import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { Observable, filter, switchMap, tap } from 'rxjs';
import { DespesasService } from 'src/app/services/despesas.service';
import { DespesasDialogComponent } from '../despesas-dialog/despesas-dialog.component';
import { ConfirmationDialogComponent } from '../shared/confirmation-dialog/confirmation-dialog.component';
import { MatSnackBar } from '@angular/material/snack-bar';
import { DespesaView } from 'src/app/models/despesaView';

@Component({
  selector: 'app-lista-de-despesas',
  templateUrl: './lista-de-despesas.component.html',
  styleUrls: ['./lista-de-despesas.component.css']
})
export class ListaDeDespesasComponent implements OnInit {

  dataSource$: Observable<DespesaView[]>;
  filtroMes$: Observable<any[]>;

  constructor(
    private despesaService: DespesasService,
    private dialog: MatDialog    
    ) {  }
  
  ngOnInit(): void {
    this.reloadListaDespesas();
  }
  
  reloadListaDespesas() {    
    this.dataSource$ = this.despesaService.getDespesas();
  }

  AddDespesa() {

    const dialogConfig = new MatDialogConfig();
 
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = "450px";

    const dialogRef =    this.dialog.open(DespesasDialogComponent, dialogConfig);    
    dialogRef.afterClosed()
      .pipe(
        filter(val => !!val),        
        tap(() => this.reloadListaDespesas())
      ).subscribe()
  }
  
  DeleteDespesa(id) {
    const dialogRef = this.dialog.open(ConfirmationDialogComponent,{
      data:{
        message: 'Você realmente deseja excluir este registro?',
        buttonText: {
          ok: 'Sim',
          cancel: 'Cancelar'
        }
      }
    });    

    dialogRef.afterClosed()
    .pipe(
      filter(val => !!val),  
      switchMap(() => this.despesaService.deleteDespesaById(id)),     
      tap(() => this.reloadListaDespesas())
    ).
    subscribe({
            next(value) {
           console.log('reload aqui');           
         },
         error(err) {
           console.log("erro:", err.message)
         },
      }  
    );
  }

  EditDespesa(despesa: DespesaView) {
    console.log(despesa)
    const dialogConfig = new MatDialogConfig();
 
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = "450px";
    
    dialogConfig.data = despesa.pagamentoId; 
    console.log(dialogConfig.data);
    const dialogRef =    this.dialog.open(DespesasDialogComponent, dialogConfig);
    
    dialogRef.afterClosed()
      .pipe(
        filter(val => !!val),        
        tap(() => this.reloadListaDespesas())
      ).subscribe()
  }

  getDespesasByMonth() {
    return 0;
  }

  displayedColumns: string[] = 
  [
   'DtItemDespesa', 
   'DescricaoItemDespesa',
   'ValorItemDespesa', 
   'NomePagante', 
   'PercentualPago', 
   'TipoDespesa',
   'CategoriaDespesa',
   'options'
  ];

}
