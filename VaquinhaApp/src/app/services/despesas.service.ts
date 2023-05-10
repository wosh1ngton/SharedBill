import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { environment } from 'src/environments/environment';
import { despesaView } from '../models/despesaView';

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
    console.log('objeto despesa', despesa);
    // const httpOptions = {
    //   headers: new HttpHeaders({
    //     'Content-Type': 'application/json'
    //   })
    // };
    return this.http.post(this.baseUrl+'Despesas',despesa);
  }
  
  getDespesas() : Observable<despesaView[]> {
    return this.http.get<despesaView[]>(this.baseUrl+'Despesas').pipe(
        map((res:despesaView[]) => {
          console.log(res);
         return res;
        })        
    );
  }
}
