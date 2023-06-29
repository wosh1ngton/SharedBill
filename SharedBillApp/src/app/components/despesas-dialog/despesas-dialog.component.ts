import { Component, EventEmitter, Inject, Output } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { filter, tap } from 'rxjs';
import { DespesaCadastro } from 'src/app/models/despesaCadastro';
import { DespesaView } from 'src/app/models/despesaView';
import { DespesasService } from 'src/app/services/despesas.service';

@Component({
  selector: 'app-despesas-dialog',
  templateUrl: './despesas-dialog.component.html',
  styleUrls: ['./despesas-dialog.component.css']
})
export class DespesasDialogComponent {
  pagantes: any;
  tiposDespesas: any;
  categoriasDespesas: any;  
  despesa: DespesaCadastro;

  constructor(
      private dialogRef: MatDialogRef<DespesasDialogComponent>,
      @Inject(MAT_DIALOG_DATA) data: number,
      private despesaService: DespesasService,
  ) { 

    if(data) {
      this.despesaService.getDespesaById(data).subscribe((desp: any) => {
        
        this.despesa = desp;
        console.log(this.despesa);
      });
    } else {
      this.despesa = new DespesaCadastro();
    }
    console.log(this.despesa);
   }
  

  ngOnInit(): void {
    this.pagantes = this.despesaService.getPagantes();  
    this.categoriasDespesas = this.despesaService.getCategoriasDespesas();
    this.tiposDespesas = this.despesaService.getTipoDespesas();
  }

  editar(despesa:DespesaCadastro) {
    console.log('despesa-dialog', despesa);
    this.despesaService.edit(despesa).pipe(
      tap(() => this.dialogRef.close(true))
    ).subscribe();
  }

  save(despesa:DespesaCadastro) {    
    
    this.despesaService.create(despesa).pipe(
      tap(() => this.dialogRef.close(true))
    ).subscribe();    
    
  }


  close() {
    this.dialogRef.close();
  }
}
