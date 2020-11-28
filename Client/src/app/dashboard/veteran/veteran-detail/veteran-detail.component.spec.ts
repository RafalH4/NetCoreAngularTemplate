import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VeteranDetailComponent } from './veteran-detail.component';

describe('VeteranDetailComponent', () => {
  let component: VeteranDetailComponent;
  let fixture: ComponentFixture<VeteranDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VeteranDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VeteranDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
