import { Injectable } from "@angular/core";
import { BehaviorSubject, Observable, catchError, map, of, tap } from "rxjs";
import { DespesaView } from "../models/despesaView";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { DespesaPorMesView } from "../models/despesaPorMesView";

@Injectable({
    providedIn: 'root'
})
export class DespesasStore {
    
    private readonly baseUrl = environment.mainUrlAPI;
    private subject = new BehaviorSubject<DespesaPorMesView[]>([]);
    despesas$: Observable<DespesaPorMesView[]> = this.subject.asObservable();

    
    constructor(       
        private http: HttpClient) {}   

    loadAllDespesasPorAno(ano?: number) {
       const loadDespesas$ = this.http.get<DespesaPorMesView[]>
        (this.baseUrl + 'Despesas/' + ano, { withCredentials: true })
            .pipe(
                map((res: DespesaPorMesView[]) =>{
                    console.log('res', res);
                    return res;
                    }),
                catchError(err => {
                    const message = "Não foi possível carregar as despesas";
                    console.log("erro",err);
                    return of(err);
                }),                
                tap(despesas => this.subject.next(despesas)),
                tap(() => console.log('teste do subject', this.subject))
            );
         
        return loadDespesas$;               
            
    }

    filtrarPorMes(mes: number): Observable<DespesaView[]> {
        return this.despesas$
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


}