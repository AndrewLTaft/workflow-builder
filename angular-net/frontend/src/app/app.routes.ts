import { Route } from '@angular/router';

export const appRoutes: Route[] = [
  {
    path: 'workflows',
    loadChildren: () =>
      import('@frontend/workflows').then((m) => m.workflowsRoutes),
  },
  { path: '', redirectTo: '/workflows', pathMatch: 'full' },
];
