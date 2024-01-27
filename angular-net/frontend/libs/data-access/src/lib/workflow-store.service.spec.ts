import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';

import { WorkflowStoreService } from './workflow-store.service';
import { COMMON_CONFIG_TOKEN } from '@frontend/common-config';

describe('WorkflowStoreService', () => {
  let service: WorkflowStoreService;

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
    service = TestBed.inject(WorkflowStoreService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
