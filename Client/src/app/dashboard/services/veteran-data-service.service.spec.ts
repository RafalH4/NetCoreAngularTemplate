import { TestBed } from '@angular/core/testing';

import { VeteranDataServiceService } from './veteran-data-service.service';

describe('VeteranDataServiceService', () => {
  let service: VeteranDataServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(VeteranDataServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
