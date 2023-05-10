import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListaDeDespesasComponent } from './lista-de-despesas.component';

describe('ListaDeDespesasComponent', () => {
  let component: ListaDeDespesasComponent;
  let fixture: ComponentFixture<ListaDeDespesasComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ListaDeDespesasComponent]
    });
    fixture = TestBed.createComponent(ListaDeDespesasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
