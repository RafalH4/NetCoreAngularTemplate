import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BusinessmanSiteComponent } from './businessman-site.component';

describe('BusinessmanSiteComponent', () => {
  let component: BusinessmanSiteComponent;
  let fixture: ComponentFixture<BusinessmanSiteComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BusinessmanSiteComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BusinessmanSiteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
