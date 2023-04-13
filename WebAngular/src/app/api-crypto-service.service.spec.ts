import { TestBed } from '@angular/core/testing';

import { ApiCryptoServiceService } from './api-crypto-service.service';

describe('ApiCryptoServiceService', () => {
  let service: ApiCryptoServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ApiCryptoServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
