import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { DespesasService } from 'src/app/services/despesas.service';
import { DespesaCadastro } from 'src/app/models/despesaCadastro';
import { tap } from 'rxjs';
@Component({
  selector: 'app-despesas',
  templateUrl: './despesas.component.html',
  styleUrls: ['./despesas.component.css']
})
export class DespesasComponent implements OnInit {

  pagantes: any;
  tiposDespesas: any;
  categoriasDespesas: any;

  @Output()
  private despesasChanged = new EventEmitter();

  constructor(private despesaService: DespesasService) {  }
  
  ngOnInit(): void {
    this.pagantes = this.despesaService.getPagantes();
    this.categoriasDespesas = this.despesaService.getCategoriasDespesas();
    this.tiposDespesas = this.despesaService.getTipoDespesas();
  }

  save(despesa:DespesaCadastro) {
    console.log(despesa)
    this.despesaService.create(despesa)
      .pipe(
        tap(() => this.despesasChanged.emit())
      ).subscribe();
  }

}
