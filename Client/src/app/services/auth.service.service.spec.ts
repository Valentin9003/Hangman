import { TestBed } from '@angular/core/testing';

import { Auth.ServiceService } from './auth.service.service';

describe('Auth.ServiceService', () => {
  let service: Auth.ServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(Auth.ServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
