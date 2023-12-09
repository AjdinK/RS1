import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Authorize2fComponent } from './authorize2f.component';

describe('Authorize2fComponent', () => {
  let component: Authorize2fComponent;
  let fixture: ComponentFixture<Authorize2fComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ Authorize2fComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Authorize2fComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
