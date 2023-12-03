import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StudentiComponent } from './studenti.component';

describe('StudentComponent', () => {
  let component: StudentiComponent;
  let fixture: ComponentFixture<StudentiComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [StudentiComponent]
    });
    fixture = TestBed.createComponent(StudentiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
