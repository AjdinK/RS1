import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TestSrijedaComponent } from './test-srijeda.component';

describe('TestSrijedaComponent', () => {
  let component: TestSrijedaComponent;
  let fixture: ComponentFixture<TestSrijedaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TestSrijedaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TestSrijedaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
