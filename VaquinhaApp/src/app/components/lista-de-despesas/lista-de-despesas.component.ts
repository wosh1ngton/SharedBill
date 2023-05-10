import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { despesaView } from 'src/app/models/despesaView';
import { DespesasService } from 'src/app/services/despesas.service';

@Component({
  selector: 'app-lista-de-despesas',
  templateUrl: './lista-de-despesas.component.html',
  styleUrls: ['./lista-de-despesas.component.css']
})
export class ListaDeDespesasComponent implements OnInit {

  dataSource$: Observable<despesaView[]>;
  
  constructor(private despesaService: DespesasService) {  }
  
  ngOnInit(): void {
    this.reloadListaDespesas();
  }

  reloadListaDespesas() {
    this.dataSource$ = this.despesaService.getDespesas();
  }
  displayedColumns: string[] = 
  [
   'DtItemDespesa', 
   'DescricaoItemDespesa',
   'ValorItemDespesa', 
   'NomePagante', 
   'PercentualPago', 
   'TipoDespesa',
   'CategoriaDespesa'
  ];

}
