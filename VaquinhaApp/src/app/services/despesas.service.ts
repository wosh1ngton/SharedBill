import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { environment } from 'src/environments/environment';
import { DespesaView } from '../models/despesaView';

@Injectable({
  providedIn: 'root'
})
export class DespesasService {  

  private readonly baseUrl = environment.mainUrlAPI;
 
  constructor(private http: HttpClient) { }

  getPagantes() {
    return this.http.get(this.baseUrl+'pagantes');
  }

  getTipoDespesas() {
    return this.http.get(this.baseUrl+'Despesas/TiposDespesas');
  }

  getCategoriasDespesas() {
    return this.http.get(this.baseUrl+'Despesas/CategoriasDespesas');
  }

  create(despesa: any) : Observable<any> {    
    return this.http.post(this.baseUrl+'Despesas',despesa);
  }

  edit(despesa:any): Observable<any> {
    console.log('Em Edição', despesa);
    return this.http.put(this.baseUrl+'Despesas/'+despesa.pagamentoId, despesa);
  }
  
  getDespesas() : Observable<DespesaView[]> {
    return this.http.get<DespesaView[]>(this.baseUrl+'Despesas').pipe(
        map((res:DespesaView[]) => {
          console.log(res);
         return res;
        })        
    );
  }

  deleteDespesaById(id:number) {
    return this.http.delete(this.baseUrl+'Despesas/'+id,{responseType: 'text'});
  }

  getDespesaById(id:number) {
    return this.http.get(this.baseUrl+'Despesas/'+id)    
  }
}
