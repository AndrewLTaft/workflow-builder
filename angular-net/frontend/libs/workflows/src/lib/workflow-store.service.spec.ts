import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';

import { WorkflowStoreService } from './workflow-store.service';

describe('WorkflowStoreService', () => {
  let service: WorkflowStoreService;

  beforeEach(() => {
    TestBed.configureTestingModule({ imports: [HttpClientTestingModule] });
    service = TestBed.inject(WorkflowStoreService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
