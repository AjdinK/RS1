import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TwoFactorOtkljucajComponent } from './two-factor-otkljucaj.component';

describe('TwoFactorOtkljucajComponent', () => {
  let component: TwoFactorOtkljucajComponent;
  let fixture: ComponentFixture<TwoFactorOtkljucajComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TwoFactorOtkljucajComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TwoFactorOtkljucajComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
