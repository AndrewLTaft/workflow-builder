import { Route } from '@angular/router';

import { MainComponent } from './main/main.component';
import { EditWorkflowComponent } from './edit-workflow/edit-workflow.component';
import { workflowResolver } from './workflow-resolver';

export const workflowsRoutes: Route[] = [
  {
    path: '',
    component: MainComponent,
    children: [
      {
        path: 'new',
        component: EditWorkflowComponent,
        data: {
          workflow: { id: undefined, name: '' },
        },
      },
      {
        path: ':id',
        component: EditWorkflowComponent,
        resolve: {
          workflow: workflowResolver,
        },
      },
    ],
  },
];
