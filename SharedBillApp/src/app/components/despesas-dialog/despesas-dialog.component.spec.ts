import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DespesasDialogComponent } from './despesas-dialog.component';

describe('DespesasDialogComponent', () => {
  let component: DespesasDialogComponent;
  let fixture: ComponentFixture<DespesasDialogComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DespesasDialogComponent]
    });
    fixture = TestBed.createComponent(DespesasDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
