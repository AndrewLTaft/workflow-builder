import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink, RouterLinkActive } from '@angular/router';

import { WorkflowStoreService } from '@frontend/data-access';

@Component({
  selector: 'frontend-workflows',
  standalone: true,
  imports: [CommonModule, RouterLink, RouterLinkActive],
  templateUrl: './workflows.component.html',
  styleUrl: './workflows.component.css',
})
export class WorkflowsComponent {
  public workflows$ = this.workflowStore.workflows$;

  constructor(private workflowStore: WorkflowStoreService) {}
}
