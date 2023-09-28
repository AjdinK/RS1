import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Proba1Component } from './proba1.component';

describe('Proba1Component', () => {
  let component: Proba1Component;
  let fixture: ComponentFixture<Proba1Component>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [Proba1Component]
    });
    fixture = TestBed.createComponent(Proba1Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
