import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NPVcalculatorComponent } from './npvcalculator.component';

describe('NPVcalculatorComponent', () => {
  let component: NPVcalculatorComponent;
  let fixture: ComponentFixture<NPVcalculatorComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [NPVcalculatorComponent]
    });
    fixture = TestBed.createComponent(NPVcalculatorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
