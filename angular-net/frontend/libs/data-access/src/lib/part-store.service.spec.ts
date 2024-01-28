import { TestBed } from '@angular/core/testing';

import { PartStoreService } from './part-store.service';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { COMMON_CONFIG_TOKEN } from '@frontend/common-config';

describe('PartStoreService', () => {
  let service: PartStoreService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [
        {
          provide: COMMON_CONFIG_TOKEN,
          useValue: {
            apiBaseURL: 'testurl/',
          },
        },
      ],
    });
    service = TestBed.inject(PartStoreService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
