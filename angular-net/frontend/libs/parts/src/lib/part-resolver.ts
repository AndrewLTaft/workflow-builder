import { inject } from '@angular/core';
import { ActivatedRouteSnapshot, ResolveFn } from '@angular/router';
import { Observable, filter } from 'rxjs';

import { Part, PartStoreService } from '@frontend/data-access';

export const partResolver: ResolveFn<Part> = (
  route: ActivatedRouteSnapshot
) => {
  const store = inject(PartStoreService);
  const id = parseInt(route.paramMap.get('id')!, 10);

  return store.ById$(id).pipe(
    filter((part) => {
      if (part) {
        return true;
      }
      return false;
    })
  ) as Observable<Part>;
};
