import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RascunhoRelatorioPage } from './rascunho-relatorio.page';

describe('RascunhoRelatorioPage', () => {
  let component: RascunhoRelatorioPage;
  let fixture: ComponentFixture<RascunhoRelatorioPage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RascunhoRelatorioPage ],
      schemas: [CUSTOM_ELEMENTS_SCHEMA],
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RascunhoRelatorioPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
