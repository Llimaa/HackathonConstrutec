import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ObraPage } from './obra.page';

describe('ObraPage', () => {
  let component: ObraPage;
  let fixture: ComponentFixture<ObraPage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ObraPage ],
      schemas: [CUSTOM_ELEMENTS_SCHEMA],
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ObraPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
