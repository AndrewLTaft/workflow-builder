import { Route } from '@angular/router';

import { MainComponent } from './main/main.component';
import { NewPartComponent } from './new-part/new-part.component';
import { EditPartComponent } from './edit-part/edit-part.component';
import { partResolver } from './part-resolver';

export const partsRoutes: Route[] = [
  {
    path: '',
    component: MainComponent,
    children: [
      { path: 'new', component: NewPartComponent },
      {
        path: ':id',
        component: EditPartComponent,
        resolve: {
          part: partResolver,
        },
      },
    ],
  },
];
