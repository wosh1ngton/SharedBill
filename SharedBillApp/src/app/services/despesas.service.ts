import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map, shareReplay, tap } from 'rxjs';
import { environment } from 'src/environments/environment';
import { DespesaView } from '../models/despesaView';
import { totais } from '../models/totais';
import { DespesaPorMesView } from '../models/despesaPorMesView';

@Injectable({
  providedIn: 'root'
})
export class DespesasService {

  private readonly baseUrl = environment.mainUrlAPI;

  constructor(private http: HttpClient) {  }

  loadDespesas$:Observable<any>;

  getPagantes() {
    return this.http.get(this.baseUrl + 'pagantes');
  }

  getTipoDespesas() {
    return this.http.get(this.baseUrl + 'Despesas/TiposDespesas');
  }

  getCategoriasDespesas() {
    return this.http.get(this.baseUrl + 'Despesas/CategoriasDespesas');
  }

  create(despesa: any): Observable<any> {
    return this.http.post(this.baseUrl + 'Despesas', despesa);
  }

  edit(despesa: any): Observable<any> {
    console.log('Em Edição', despesa);
    return this.http.put(this.baseUrl + 'Despesas/' + despesa.pagamentoId, despesa);
  }

  loadDespesasPorAno(ano?: number) {
    this.loadDespesas$ = this.http.get<DespesaPorMesView[]>(this.baseUrl + 'Despesas/' + ano, {withCredentials:true})
    .pipe(      
      map((res: DespesaPorMesView[]) => {                        
        return res;
      })
    );  
  }

  filtrarPorMes(mes: number): Observable<DespesaView[]> {
    return this.loadDespesas$
        .pipe(
            map(
                (desp) => {
                  console.log('aqui!',desp);
                  
                  return desp.find(despesa => {                            
                        console.log('mes comparador',despesa['Mes']);
                        console.log('mes clicado', mes)
                        return despesa.Mes == mes
                  }).Despesas;
                }),
            tap((val) => console.log('valor filtrado por mes', val))
        )
}

  deleteDespesaById(id: number) {
    return this.http.delete(this.baseUrl + 'Despesas/' + id, { responseType: 'text' });
  }

  getDespesaById(id: number) {
    return this.http.get(this.baseUrl + 'Despesas/GetById/' + id)
  }

  getMesesFiltroPorAno(ano?: number): Observable<any> {
    return this.http.get(this.baseUrl + 'Despesas/MesesComDespesaPorAno/' + ano)
  }

  getAnosComDespesas(): Observable<any> {
    return this.http.get(this.baseUrl + 'Despesas/AnosComDespesas',{withCredentials:true});
  }

  getTotalReceber(ano: number): Observable<any> {
    return this.http.get(this.baseUrl + 'Despesas/totalReceber/' + ano)
  }

  getSaldo(val: totais[]): totais[] {
    if (val[1]) {
      if (val[0].totalAReceber > val[1].totalAReceber) {
        val[0].saldo = val[0].totalAReceber - val[1].totalAReceber;
        val[1].saldo = 0;
      } else if (val[1].totalAReceber > val[0].totalAReceber) {
        val[1].saldo = val[1].totalAReceber - val[0].totalAReceber;
        val[0].saldo = 0;
      } else {
        val[0].saldo = 0;
        val[1].saldo = 0;
      }
    } else {
      if (val[0]) {
        val[0].saldo = val[0].totalAReceber;
      }
    }
    return val;
  }

}
