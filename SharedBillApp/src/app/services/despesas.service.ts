import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map, tap } from 'rxjs';
import { environment } from 'src/environments/environment';
import { DespesaView } from '../models/despesaView';
import { totais } from '../models/totais';

@Injectable({
  providedIn: 'root'
})
export class DespesasService {

  private readonly baseUrl = environment.mainUrlAPI;

  constructor(private http: HttpClient) { }

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

  getDespesas(ano?: number): Observable<DespesaView[]> {
    return this.http.get<DespesaView[]>(this.baseUrl + 'Despesas/' + ano).pipe(
      map((res: DespesaView[]) => {
        //console.log(new Date(res[0].dtItemDespesa).getMonth());
        return res;
      })

    );
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
    return this.http.get(this.baseUrl + 'Despesas/AnosComDespesas');
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
