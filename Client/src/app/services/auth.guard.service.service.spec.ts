import { TestBed } from '@angular/core/testing';

import { Auth.Guard.ServiceService } from './auth.guard.service.service';

describe('Auth.Guard.ServiceService', () => {
  let service: Auth.Guard.ServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(Auth.Guard.ServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
