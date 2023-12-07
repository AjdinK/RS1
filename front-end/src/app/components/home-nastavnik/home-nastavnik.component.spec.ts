import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HomeNastavnikComponent } from './home-nastavnik.component';

describe('HomeNastavnikComponent', () => {
  let component: HomeNastavnikComponent;
  let fixture: ComponentFixture<HomeNastavnikComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HomeNastavnikComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HomeNastavnikComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
