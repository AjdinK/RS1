import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DrzaveComponent } from './drzave.component';

describe('DrzaveComponent', () => {
  let component: DrzaveComponent;
  let fixture: ComponentFixture<DrzaveComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DrzaveComponent]
    });
    fixture = TestBed.createComponent(DrzaveComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
