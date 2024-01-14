import { inject } from '@angular/core';
import { ActivatedRouteSnapshot, ResolveFn, Router } from '@angular/router';
import { EMPTY, mergeMap, of } from 'rxjs';

import { Workflow, WorkflowStoreService } from './workflow-store.service';

export const workflowResolver: ResolveFn<Workflow> = (
  route: ActivatedRouteSnapshot
) => {
  const router = inject(Router);
  const store = inject(WorkflowStoreService);
  const id = parseInt(route.paramMap.get('id')!, 10);

  return store.ById$(id).pipe(
    mergeMap((workflow) => {
      if (workflow) {
        return of(workflow);
      } else {
        // id not found
        router.navigate(['/']);
        return EMPTY;
      }
    })
  );
};
