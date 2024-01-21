import { Route } from '@angular/router';

export const appRoutes: Route[] = [
  {
    path: 'parts',
    loadChildren: () => import('@frontend/parts').then((m) => m.partsRoutes),
  },
  {
    path: 'workflows',
    loadChildren: () =>
      import('@frontend/workflows').then((m) => m.workflowsRoutes),
  },
  { path: '', redirectTo: '/workflows', pathMatch: 'full' },
];
