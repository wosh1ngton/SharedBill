import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { Observable, filter, map, switchMap, tap } from 'rxjs';
import { DespesasService } from 'src/app/services/despesas.service';
import { DespesasDialogComponent } from '../despesas-dialog/despesas-dialog.component';
import { ConfirmationDialogComponent } from '../shared/confirmation-dialog/confirmation-dialog.component';
import { DespesaView } from 'src/app/models/despesaView';
import { totais } from 'src/app/models/totais';

@Component({
  selector: 'app-lista-de-despesas',
  templateUrl: './lista-de-despesas.component.html',
  styleUrls: ['./lista-de-despesas.component.css']
})
export class ListaDeDespesasComponent implements OnInit {

  dataSource$: Observable<DespesaView[]>;
  filtroMes$: Observable<any[]>;
  Anos$: Observable<any[]>;
  totais$: Observable<totais[]>;
  mesSelecionado: number;
  anoSelecionado: number;

  constructor(
    private despesaService: DespesasService,
    private dialog: MatDialog
  ) { }

  ngOnInit(): void {
    if (this.anoSelecionado == null) {
      this.anoSelecionado = new Date().getFullYear();
    }
    this.reloadListaDespesas(this.anoSelecionado);
    this.getMeses(this.anoSelecionado);
    this.getAnos();
    this.getTotais(this.anoSelecionado);
  }

  getAnos() {
    this.Anos$ = this.despesaService.getAnosComDespesas();
  }

  getMeses(ano?: number) {
    this.filtroMes$ = this.despesaService.getMesesFiltroPorAno(ano)
      .pipe(
        map((meses) => {
          
          let mes = meses.find(element => {
            element.mesString = element.mesString.slice(0,3),
            element.mesInteiro == this.mesSelecionado
            }
          );
          if (mes) {
            mes.selected = true;
          } else {
            meses[0].selected = true;
            this.mesSelecionado = meses[0].mesInteiro;
            this.reloadListaDespesas(ano)
          }
          return meses;
        }), tap(() => console.log('getMeses called')))
  }

  reloadListaDespesas(ano?: number) {

    this.dataSource$ = this.despesaService.getDespesas(ano)
      .pipe(map(
        (desp) => {
          console.log(desp);
          return desp.filter(despesa =>
            (new Date(despesa.dtItemDespesa).getMonth() + 1) == this.mesSelecionado)
        }
      ),
        tap((desp) => console.log('reload called', this.mesSelecionado))
      );

  }

  getTotais(ano?:number) {
    this.totais$ = this.despesaService.getTotalReceber(ano)
      .pipe(
        map((val:totais[]) => {          
          return val.filter(m =>             
             (m.mesTotalizado == this.mesSelecionado)            
          )         
        }),
        map(val => this.despesaService.getSaldo(val)
        )
      )
  }

  //TODO - Selecionar (destacar) o mês da última operação cadastrada
  AddDespesa() {

    const dialogConfig = new MatDialogConfig();

    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = "450px";

    const dialogRef = this.dialog.open(DespesasDialogComponent, dialogConfig);
    dialogRef.afterClosed()
      .pipe(
        filter(val => !!val),
        tap(() => this.reloadListaDespesas(this.anoSelecionado)),        
        tap(() => this.getMeses(this.anoSelecionado)),
        tap((val) => console.log('valor val', val))
      ).subscribe()
  }

  DeleteDespesa(id) {
    const dialogRef = this.dialog.open(ConfirmationDialogComponent, {
      data: {
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
        tap(() => this.reloadListaDespesas(this.anoSelecionado))
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
    //console.log(despesa)
    const dialogConfig = new MatDialogConfig();

    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = "450px";

    dialogConfig.data = despesa.pagamentoId;
    console.log(dialogConfig.data);
    const dialogRef = this.dialog.open(DespesasDialogComponent, dialogConfig);

    dialogRef.afterClosed()
      .pipe(
        filter(val => !!val),
        tap(() => this.reloadListaDespesas(this.anoSelecionado)),
      ).subscribe(() => this.getMeses(this.anoSelecionado))
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
