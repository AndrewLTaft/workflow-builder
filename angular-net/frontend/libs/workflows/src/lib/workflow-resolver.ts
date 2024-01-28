import { inject } from '@angular/core';
import { ActivatedRouteSnapshot, ResolveFn } from '@angular/router';
import { Observable, filter } from 'rxjs';

import { Workflow, WorkflowStoreService } from '@frontend/data-access';

export const workflowResolver: ResolveFn<Workflow> = (
  route: ActivatedRouteSnapshot
) => {
  const store = inject(WorkflowStoreService);
  const id = parseInt(route.paramMap.get('id')!, 10);

  return store.ById$(id).pipe(
    filter((workflow) => {
      if (workflow) {
        return true;
      }
      return false;
    })
  ) as Observable<Workflow>;
};
